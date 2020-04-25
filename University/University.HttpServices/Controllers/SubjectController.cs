namespace University.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using University.InputModels;
    using University.Services;

    [Route("api/subject")]
    [Authorize]
    public class SubjectController : BaseServiceController<ISubjectService>
    {
        public SubjectController(ISubjectService service)
            : base(service)
        { }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = this.service.GetAll();
            return this.Ok(result);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = this.service.Get(id);
            return this.Ok(result);
        }

        [HttpPost]
        [Authorize(Policy = "RequireAdminOrTeacherRole")]
        public IActionResult Save(SubjectInputModel model)
        {
            this.service.Save(model);
            return this.Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        [Authorize(Policy = "RequireAdminOrTeacherRole")]
        public IActionResult Delete(int id)
        {
            this.service.Delete(id);
            return this.Ok();
        }
    }
}
