namespace RecruitmentTask.Models
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System.Globalization;

    public class DecimalBinder : IModelBinder
        {
            public Task BindModelAsync(ModelBindingContext bindingContext)
            {
                var valueProviderResult = bindingContext
                    .ValueProvider
                    .GetValue(bindingContext.ModelName);

                var cultureInfo = new CultureInfo("en-US");

                double.TryParse(
                    valueProviderResult.FirstValue,
                    NumberStyles.AllowDecimalPoint,
                    cultureInfo,
                    out var model);

                bindingContext
                    .ModelState
                    .SetModelValue(bindingContext.ModelName, valueProviderResult);

                bindingContext.Result = ModelBindingResult.Success(Convert.ToDecimal(model));
                return Task.CompletedTask;
            }
        }
    }

