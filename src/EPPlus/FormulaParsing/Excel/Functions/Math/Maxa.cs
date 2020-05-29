/*************************************************************************************************
  Required Notice: Copyright (C) EPPlus Software AB. 
  This software is licensed under PolyForm Noncommercial License 1.0.0 
  and may only be used for noncommercial purposes 
  https://polyformproject.org/licenses/noncommercial/1.0.0/

  A commercial license to use this software can be purchased at https://epplussoftware.com
 *************************************************************************************************
  Date               Author                       Change
 *************************************************************************************************
  01/27/2020         EPPlus Software AB       Initial release EPPlus 5
 *************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Metadata;
using OfficeOpenXml.FormulaParsing.ExpressionGraph;
using OfficeOpenXml.FormulaParsing.Utilities;

namespace OfficeOpenXml.FormulaParsing.Excel.Functions.Math
{
    [FunctionMetadata(
        Category = ExcelFunctionCategory.Statistical,
        EPPlusVersion = "4",
        Description = "Returns the largest value from a list of supplied values, counting text and the logical value FALSE as the value 0 and counting the logical value TRUE as the value 1")]
    internal class Maxa : ExcelFunction
    {
        private readonly DoubleEnumerableArgConverter _argConverter;

        public Maxa()
            : this(new DoubleEnumerableArgConverter())
        {

        }
        public Maxa(DoubleEnumerableArgConverter argConverter)
        {
            Require.That(argConverter).Named("argConverter").IsNotNull();
            _argConverter = argConverter;
        }
        public override CompileResult Execute(IEnumerable<FunctionArgument> arguments, ParsingContext context)
        {
            ValidateArguments(arguments, 1);
            var values = _argConverter.ConvertArgsIncludingOtherTypes(arguments);
            return CreateResult(values.Max(), DataType.Decimal);
        }
    }
}
