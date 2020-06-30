using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class QuoteService : IQuoteService
    {
        private ScriptsContext _context;
        private IRandomService _randomService;

        public QuoteService(ScriptsContext context, IRandomService randomService)
        {
            this._context = context;
            this._randomService = randomService;
        }

        public Quote GetAnyQuote()
        {
            var quotes = _context.Quotes.ToList();            
            return GetRandomQuote(quotes);
        }

        public Quote GetAnyQuote(string actor)
        {
            var quotesActor = _context.Quotes.Where(q => q.Actor == actor).ToList();
            return GetRandomQuote(quotesActor);
        }

        private Quote GetRandomQuote(List<Quote> quotes)
        {
            int numQuotes = quotes.Count();
            int randomInt = _randomService.RandomInteger(numQuotes);

            return numQuotes > 0 ? quotes[randomInt] : null;
        }
    }
}