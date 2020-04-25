namespace University_frontend.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ValidateHelper
    {
        public static string Validate(object data)
        {
            var errorList = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(data, new ValidationContext(data, null, null), errorList, true);

            StringBuilder errorMessage = new StringBuilder();

            if (!isValid)
            {
                foreach (var error in errorList)
                {
                    errorMessage.Append(error.ErrorMessage + Environment.NewLine);
                }
            }

            return errorMessage.ToString().Trim();
        }
    }
}
