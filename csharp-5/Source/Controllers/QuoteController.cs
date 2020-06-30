using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _service;       

        public QuoteController(IQuoteService service)
        {
            _service = service;
        }

        // GET api/quote
        [HttpGet]
        public ActionResult<QuoteView> GetAnyQuote()
        {
            var quote = _service.GetAnyQuote();

            if (quote == null)
                return NotFound();

            return GetQuoteView(quote);
        }

        // GET api/quote/{actor}
        [HttpGet("{actor}")]
        public ActionResult<QuoteView> GetAnyQuote(string actor)
        {
            //Retorna uma frase aleatória do ator passado como parâmetro.
            var quote = _service.GetAnyQuote(actor);

            if (quote == null)
                return NotFound();

            return GetQuoteView(quote);
        }

        private QuoteView GetQuoteView(Quote quote)
        {
            var quoteView = new QuoteView()
            {
                Id = quote.Id,
                Actor = quote.Actor,
                Detail = quote.Detail
            };

            return quoteView;
        }

    }
}
