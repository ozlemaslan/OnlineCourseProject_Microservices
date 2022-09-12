
namespace FreeCourse.Shared.ControllerBases
{
    using FreeCourse.Shared.Dtos;
    using Microsoft.AspNetCore.Mvc;
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
