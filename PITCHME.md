# Web API on CRM **Show & Tell**

---
@title[What Will be Covered?]

@snap[north-west span-50 text-center]
#### What Will be Covered?
@snapend

@snap[west span-55]
@ul[list-spaced-bullets text-09]
- What's Api?
- Why Web Api?
- Words about MicroService
- Archetectual Design of Web Api on CRM
- Dive into Codes
- Unit Testing
- Test Tools
- What's Next?
@ulend
@snapend

@snap[east span-45]
![IMAGE](assets/img/conference.png)
@snapend

@snap[south span-100 bg-black fragment]
@img[shadow](assets/img/conference.png)
@snapend

---

@snap[north-east span-100 text-pink text-06]
Let our code do the talking!
@snapend

```c# zoom-18
namespace StudentDataServiceAPI.Controllers.Crm
{
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
}
```

@snap[south span-100 text-gray text-08]
@[3-6](Authorize - providing authorization; ApiController - get default behaviours; Route - avoid using [controller] with strong coupling to class name)
@[7-13, zoom-13](Injecting ICrmAltChoiceCreateService as dependency)
@[24-31, zoom-13](Calling service to create alternative offer)
@[33-40, zoom-12](Retuns response to caller depending on status)
@snapend


---?image=assets/img/code.jpg&opacity=60&position=left&size=45% 100%

@snap[east span-50 text-center]
## Now Let's **Run** the Codes
@snapend

