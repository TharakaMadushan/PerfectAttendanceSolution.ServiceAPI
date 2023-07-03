using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerfectAttendanceSolution.IRepository.IRepository;
using System.Data;
using System.Reflection;

namespace PerfectAttendanceSolution.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AttMangeController : ControllerBase
    {
        private readonly IAttMgt _repo;

        public AttMangeController(IAttMgt repo)
        {
            _repo = repo;
        }

        [Authorize]
        [HttpPost()]
        [ActionName("saveAttendanceDetails")]
        public async Task<IActionResult> saveAttendanceDetails(DataTable dtAttendance)
        {
            bool exist = false;
            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(Att);
            var results = await _repo.saveAttendanceDetails(dtAttendance);
            if (results == "OK")
            {
                return Ok("Insert Sucessfully");
            }

            return BadRequest("API Error");
        }

        [HttpGet("{LocationID}")]
        [ActionName("getLoacationDetails")]
        public async Task<IActionResult> getLoacationDetails(int LocationID)
        {
            //string jason = "";
            var results = await _repo.GetMachineDetails(LocationID);
            //jason = JsonConvert.SerializeObject(results);
            return Ok(results);
        }

        [HttpGet("{LocationID}")]
        [ActionName("getCurrentLoacationDetails")]
        public async Task<IActionResult> getCurrentLoacationDetails(int LocationID)
        {
            var results = await _repo.GetcurrentLocationDetails(LocationID);
            return Ok(results);
        }

        [HttpGet("{MachineEntryID}/{FromDate}/{ToDate}")]
        [ActionName("getAttendanceDetails")]
        public async Task<IActionResult> getAttendanceDetails(int MachineEntryID, DateTime FromDate, DateTime ToDate)
        {
            var results = await _repo.getAttendanceDetails(MachineEntryID, FromDate, ToDate);
            return Ok(results);
        }

        [HttpGet]
        [ActionName("getConnectivity")]
        public async Task<IActionResult> getConnectivity()
        {
            var results = true;
            return Ok(results);
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}