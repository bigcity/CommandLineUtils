// Copyright (c) Nate McMaster.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;

namespace McMaster.Extensions.CommandLineUtils
{
    static partial class ValidationExtensions
    {
        /// <summary>
        /// Indicates the option, when specified, must be an email address.
        /// </summary>
        /// <param name="option">The option.</param>
        /// <param name="errorMessage">The error message to display. See also <seealso cref="ValidationAttribute.ErrorMessage"/>.</param>
        /// <returns>The option.</returns>
        public static CommandOption IsEmailAddress(this CommandOption option, string errorMessage = null)
        {
            option.Validators.Add(
                new AttributeValidator(
                    GetValidator<EmailAddressAttribute>(errorMessage)));
            return option;
        }

        /// <summary>
        /// Indicates the argument is required.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="errorMessage">The error message to display. See also <seealso cref="ValidationAttribute.ErrorMessage"/>.</param>
        /// <returns>The argument.</returns>
        public static CommandArgument IsEmailAddress(this CommandArgument argument, string errorMessage = null)
        {
            argument.Validators.Add(
                new AttributeValidator(
                    GetValidator<EmailAddressAttribute>(errorMessage)));
            return argument;
        }

        private static T GetValidator<T>(string errorMessage)
            where T : ValidationAttribute, new()
        {
            var attribute = new T();
            if (errorMessage != null)
            {
                attribute.ErrorMessage = errorMessage;
            }
            return attribute;
        }
    }
}
