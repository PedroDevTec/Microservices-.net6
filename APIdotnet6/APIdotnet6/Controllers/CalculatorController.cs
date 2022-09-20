using Microsoft.AspNetCore.Mvc;

namespace APIdotnet6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        
        private readonly ILogger<CalculatorController> _logger;
        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{fistNumber}/{secondNumber}")]
        public IActionResult Get(string fistNumber, string secondNumber)
        {
            if (IsNumeric(fistNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(fistNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
             return BadRequest("invalid input");
        }
        
        [HttpGet("min/{fistNumber}/{secondNumber}")]
        public IActionResult Getmin(string fistNumber, string secondNumber)
        {
            if (IsNumeric(fistNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(fistNumber) - ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
             return BadRequest("invalid input");
        }
        [HttpGet("div/{fistNumber}/{secondNumber}")]
        public IActionResult Getdiv(string fistNumber, string secondNumber)
        {
            if (IsNumeric(fistNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(fistNumber) / ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("invalid input");
        }
        [HttpGet("mult/{fistNumber}/{secondNumber}")]
        public IActionResult Getmult(string fistNumber, string secondNumber)
        {
            if (IsNumeric(fistNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(fistNumber) * ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("invalid input");
        }
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string strnumber)
        {
            double number;
            bool isnumber = double.TryParse(
                strnumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.
                InvariantInfo, out number);
            return isnumber;
        }

    }
}