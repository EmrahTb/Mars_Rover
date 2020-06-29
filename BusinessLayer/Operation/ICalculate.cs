using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Operation
{
    public interface ICalculate 
    {
        List<CalculateResponse> Moving(CalculeteRequest calculateRequest);

    }
}
