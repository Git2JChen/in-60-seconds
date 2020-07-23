    [Authorize]
    [ApiController]
    [Route("api/CrmAltChoice")]
    public class CrmAltChoiceController : Controller
    {
        private ICrmAltChoiceCreateService _service;

        public CrmAltChoiceController(ICrmAltChoiceCreateService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public IActionResult Create(AltChoiceRequest request)
        {
            var response = new ApiResponse
            {
                Status = Enums.ResponseCodes.ERROR,
                Errors = new List<Error>()
            };

            try
            {
                response = _service.CreateAsync(request).Result;
            }
            catch(Exception ex)
            {
                response.Errors = new List<Error> { new Error { Message = ex.Message, Source = $"CrmAltChoiceController: {ex.Source}" } };
            }

            if(response.Status == Enums.ResponseCodes.SUCCESS)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Errors);
            }
        }
    }