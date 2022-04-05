using System.Linq;
using NUnit.Framework;

namespace PasswordInputFieldValidation {
    public class PasswordValidatorSpecs {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void no_validate_password_when_string_be_less_8_characters_long() {
            var password = "a";

            var validate = PasswordInputField.Validate(password);

            Assert.AreEqual(false, validate.Valid);
        }

        [Test]
        public void return_specific_message_when_string_be_less_8_characters_long() {
            var password = "a12";

            var validate = PasswordInputField.Validate(password);

            Assert.AreEqual(validate.Message.Contains("Password must be at least 8 characters"), true);
        }

        [Test]
        public void return_non_valid_password_and_specific_message_when_string_doesnt_have_two_number() {
            var password = "abcdefg4";

            var validate = PasswordInputField.Validate(password);

            Assert.AreEqual(false, validate.Valid);
            Assert.AreEqual(validate.Message.Contains("The password must contain at least 2 numbers"), true);
        }

        [Test]
        public void return_non_valid_password_and_specific_message_when_string_doesnt_have_one_capital_letter() {
            var password = "abcdefg4";

            var validate = PasswordInputField.Validate(password);

            Assert.AreEqual(false, validate.Valid);
            Assert.AreEqual(validate.Message.Contains("The password must contain at least one capital letter"), true);
        }


        [Test]
        public void return_two_messages_when_string_doesnt_have_two_number_and_lengh_less_than_8() {
            var password = "abcdfg4";

            var validate = PasswordInputField.Validate(password);

            Assert.AreEqual(false, validate.Valid);
            Assert.AreEqual(validate.Message.Contains("Password must be at least 8 characters"), true);
            Assert.AreEqual(validate.Message.Contains("The password must contain at least 2 numbers"), true);
        }
    }

    public static class PasswordInputField {
        public static Result Validate(string inputPassword) {
            var result = new Result { Valid = true, Message = string.Empty };
            if (inputPassword.Length < 8) {
                result.Valid = false;
                result.Message = "Password must be at least 8 characters";
            }

            if (inputPassword.Count(char.IsDigit) < 2) {
                result.Valid = false;
                if (result.Message != string.Empty) result.Message = $"{result.Message}\n";
                result.Message = $"{result.Message}The password must contain at least 2 numbers";
            }

            if (inputPassword.Count(char.IsUpper) == 0) {
                result.Valid = false;
                if (result.Message != string.Empty) result.Message = $"{result.Message}\n";
                result.Message = $"{result.Message}The password must contain at least one capital letter";
            }

            return result;
        }
    }

    public class Result {
        public bool Valid { get; set; }
        public string Message { get; set; }
    }
}