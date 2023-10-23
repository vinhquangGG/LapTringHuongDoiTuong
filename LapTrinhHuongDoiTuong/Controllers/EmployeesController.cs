using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LapTrinhHuongDoiTuong.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
         #region Field
        private IEmployeeBL _employeeBL;
        #endregion
        #region Property
        #endregion
        #region Contructer
        public EmployeesController(IEmployeeBL employeeBL)
        {
            _employeeBL = employeeBL;
        }
        /// <summary>
        /// Lấy tất cả nhân viên
        /// </summary>
        /// <returns>Danh sách tất cả nhân viên</returns>
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employees = _baseBL.GetAllRecords();
                return StatusCode(StatusCodes.Status200OK, employees);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(
                AmisErrorCode.Exception,
                Resource.DevMsg_Exception,
                Resource.UserMsg_Exception,
                Resource.MoreInfo_InsertFailed,
                HttpContext.TraceIdentifier));
            }
        }
    }
}
