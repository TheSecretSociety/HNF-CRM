// ***************************************************** //
// *                ACTIVE ALL FUNCTION                * //
// ***************************************************** //
// $(document).ready() type one only, so all functions will be when the page is loaded
$(document).ready(function () {
    LoginValidation();
    EmployeePersonalValidation();
    CustomerDetailValidation();
    ContractDetailDesignValidation();
    EmployeeAddValidation();
    ClearButton();
    DeleteButtonWarning();
    ProductionProgressBar();
    DemoChart();

});

// ----------------------------------------------------- //
// ---------------- GENERAL UI FUNCTION ---------------- //
// ----------------------------------------------------- //
// Clear button //
function ClearButton() {
    // script for Cancle Buttons
    $("#Cancle-Button").click(function () {
        $("input, textarea, select").val('').prop('checked', false);
        $("option").prop("selected", function () { return this.defaultSelected; });
    });
}
// Delete Button Warning //
function DeleteButtonWarning() {
    $('#EmployeeDeleteBtn').click(function () {
        DeleteWarning();
    })
    $('#CustomerDetailDeleteBtn').click(function () {
        DeleteWarning();
    })
    $('#CustomerDeleteBtn').click(function () {
        DeleteWarning();
    });
    function DeleteWarning() {
        var DeleteState = confirm("Bạn Có Chắc Chắn Muốn Xoá ?");
        if (DeleteState == true) {
            alert("Xoá Thành Công!");
            return true;
        } else {
            alert("Đã Huỷ Lệnh Xoá");
            return false;
        }
    }
}
// Production line Bar animation //
function ProductionProgressBar() {
    if ($("#check1:checked").length > 0) {
        $('#progress1').css('width', '100%').css('transition', '0.5s')
        $('#progress2').css('width', '50%').css('transition', '0.5s').css('transition-delay', '0.1s')
        $("#check2").prop("disabled", false);
    }
    if ($("#check2:checked").length > 0) {
        $('#progress2').css('width', '100%').css('transition', '0.5s')
        $('#progress3').css('width', '50%').css('transition', '0.5s').css('transition-delay', '0.1s')
        $("#check1").prop("disabled", true);
        $("#check3").prop("disabled", false);
    }
    if ($("#check3:checked").length > 0) {
        $('#progress3').css('width', '100%').css('transition', '0.5s')
        $('#progress4').css('width', '50%').css('transition', '0.5s').css('transition-delay', '0.1s')
        $("#check2").prop("disabled", true);
        $("#check4").prop("disabled", false);
    }
    if ($("#check4:checked").length > 0) {
        $('#progress4').css('width', '100%').css('transition', '0.5s')
        $('#progress5').css('width', '50%').css('transition', '0.5s').css('transition-delay', '0.1s')
        $("#check3").prop("disabled", true);
        $("#check5").prop("disabled", false);
    }
    if ($("#check5:checked").length > 0) {
        $('#progress5').css('width', '100%').css('transition', '0.5s')
        $('#progress6').css('width', '50%').css('transition', '0.5s').css('transition-delay', '0.1s')
        $("#check4").prop("disabled", true);
        $("#check6").prop("disabled", false);
    }
    if ($("#check6:checked").length > 0) {
        $('#progress6').css('width', '100%').css('transition', '0.5s')
        $("#check5").prop("disabled", true);
    }
    $('#check1').change(function () {
        // this will contain a reference to the checkbox
        if (this.checked) {
            // the checkbox1 is now checked
            $('#progress1').css('width', '100%').css('transition', '0.5s')
            $('#progress2').css('width', '50%').css('transition', '0.5s').css('transition-delay', '0.1s')
            $("#check2").prop("disabled", false);
        } else {
            // the checkbox1 is now no longer checked
            $('#progress1').css('width', '50%').css('transition', '0.5s').css('transition-delay', '0.1s')
            $('#progress2').css('width', '0%').css('transition', '0.5s')
            $("#check2").prop("disabled", true);

        }
    });
    $('#check2').change(function () {
        // this will contain a reference to the checkbox
        if (this.checked) {
            // the checkbox2 is now checked
            $('#progress2').css('width', '100%').css('transition', '0.5s')
            $('#progress3').css('width', '50%').css('transition', '0.5s').css('transition-delay', '0.1s')
            $("#check1").prop("disabled", true);
            $("#check3").prop("disabled", false);
        } else {
            // the checkbox2 is now no longer checked
            $('#progress2').css('width', '50%').css('transition', '0.5s').css('transition-delay', '0.1s')
            $('#progress3').css('width', '0%').css('transition', '0.5s')
            $("#check1").prop("disabled", false);
            $("#check3").prop("disabled", true);
        }
    });
    $('#check3').change(function () {
        // this will contain a reference to the checkbox
        if (this.checked) {
            // the checkbox3 is now checked
            $('#progress3').css('width', '100%').css('transition', '0.5s')
            $('#progress4').css('width', '50%').css('transition', '0.5s').css('transition-delay', '0.1s')
            $("#check2").prop("disabled", true);
            $("#check4").prop("disabled", false);
        } else {
            // the checkbox3 is now no longer checked
            $('#progress3').css('width', '50%').css('transition', '0.5s').css('transition-delay', '0.1s')
            $('#progress4').css('width', '0%').css('transition', '0.5s')
            $("#check2").prop("disabled", false);
            $("#check4").prop("disabled", true);
        }
    });
    $('#check4').change(function () {
        // this will contain a reference to the checkbox
        if (this.checked) {
            // the checkbox4 is now checked
            $('#progress4').css('width', '100%').css('transition', '0.5s')
            $('#progress5').css('width', '50%').css('transition', '0.5s').css('transition-delay', '0.1s')
            $("#check3").prop("disabled", true);
            $("#check5").prop("disabled", false);
        } else {
            // the checkbox4 is now no longer checked
            $('#progress4').css('width', '50%').css('transition', '0.5s').css('transition-delay', '0.1s')
            $('#progress5').css('width', '0%').css('transition', '0.5s')
            $("#check3").prop("disabled", false);
            $("#check5").prop("disabled", true);
        }
    });
    $('#check5').change(function () {
        // this will contain a reference to the checkbox
        if (this.checked) {
            // the checkbox5 is now checked
            $('#progress5').css('width', '100%').css('transition', '0.5s')
            $('#progress6').css('width', '50%').css('transition', '0.5s').css('transition-delay', '0.1s')
            $("#check4").prop("disabled", true);
            $("#check6").prop("disabled", false);
        } else {
            // the checkbox5 is now no longer checked
            $('#progress5').css('width', '50%').css('transition', '0.5s').css('transition-delay', '0.1s')
            $('#progress6').css('width', '0%').css('transition', '0.5s')
            $("#check4").prop("disabled", false);
            $("#check6").prop("disabled", true);
        }
    });
    $('#check6').change(function () {
        // this will contain a reference to the checkbox
        if (this.checked) {
            // the checkbox6 is now checked
            $('#progress6').css('width', '100%').css('transition', '0.5s')
            $("#check5").prop("disabled", true);

        } else {
            // the checkbox6 is now no longer checked
            $('#progress6').css('width', '50%').css('transition', '0.5s')
            $("#check5").prop("disabled", false);


        }
    });
}
// ----------------------------------------------------- //
// --------------------- VALIDATION -------------------- //
// ----------------------------------------------------- //
// HNF-Login Validation //
function LoginValidation() {
    Validate();
    // keyboard input listener (Enter Key)
    function KeyboardInput() {
        $("#TxtLoginPassword").change(function (event) {
            if (event.keyCode == 13) {
                $("#LoginButton").click();
            }
        });
        $("#TxtLoginID").change(function (event) {
            if (event.keyCode == 13) {
                $("#LoginButton").click();
            }
        });
    }
    // calling validate funtions
    function Validate() {
        $('#TxtLoginID').change(function IDValidation() {
            var UsernameValue = $('#TxtLoginID').val();
            $('.IDError').empty();
            if (LoginUsernameValidate(UsernameValue)) {
                $('.IDError').empty();
                // nếu đúng controller sẽ thực hiện
                return true;
            } else {
                $('.IDError').append('<small style="color:white;">Vui lòng nhập lại Email!</small>');
                return false;
            }
        });
        $('#TxtLoginPassword').change(function PasswordValidation() {
            var PasswordValue = $('#TxtLoginPassword').val();
            $('.PasswordError').empty();
            if (LoginPasswordValidate(PasswordValue)) {
                $('.PasswordError').empty();
                // nếu đúng controller sẽ thực hiện
                return true;
            } else {
                $('.PasswordError').append('<small style="color:white;">Password không được có khoản trắng!');
                return false;
            }
        });
    }
    // validate email format
    function LoginUsernameValidate(TxtLoginID) {
        var EmailRegEx = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        console.log('Email ID :' + EmailRegEx.test(TxtLoginID));
        return EmailRegEx.test(TxtLoginID);
    }
    // validate password format
    function LoginPasswordValidate(TxtLoginPassword) {
        var PasswordRegEx = /^.\S{1,}$/;
        console.log('Password :' + PasswordRegEx.test(TxtLoginPassword));
        return PasswordRegEx.test(TxtLoginPassword);
    }
}
// HNF-Employee-Personal Validation //
function EmployeePersonalValidation(form) {
    EditInfoValidate();
    EditPasswordValidate();
    $('#formEPInfoEdit').submit(function (event) {
        EditInfoValidate();
    })
    $('#formEPPasswordEdit').submit(function (event) {
        EditPasswordValidate();
    })
    function EditInfoValidate() { // validate when user change personal infor
        var NamePass = 0;
        var PhonePass = 0;
        var MailPass = 0;
        EPPreLoadInfoValidate();
        $('#txt-EPName').focusout(function () {
            var NameValue = $('#txt-EPName').val();
            if (EmployeeNameValidate(NameValue)) {
                $(this).removeClass('input-validate-wrong');
                NamePass = 1;
            } else {
                $(this).addClass('input-validate-wrong').val('');
                NamePass = 0;
            }
        })
        $('#txt-EPPhone').focusout(function () {
            var PhoneValue = $(this).val();
            if (EmployeePhoneValidate(PhoneValue)) {
                $(this).removeClass('input-validate-wrong');
                PhonePass = 1;
            } else {
                $(this).addClass('input-validate-wrong').val('');
                PhonePass = 0;
            }
        })
        $('#txt-EPMail').focusout(function () {
            var EmailValue = $(this).val();
            if (EmployeeEmailValidate(EmailValue)) {
                $(this).removeClass('input-validate-wrong');
                MailPass = 1;
            } else {
                $(this).addClass('input-validate-wrong').val('');
                MailPass = 0;
            }
        })
        function EPPreLoadInfoValidate() {
            if ($('#txt-EPName').length > 0) {
                var NameValue = $('#txt-EPName').val();
                if (EmployeeNameValidate(NameValue)) {
                    $(this).removeClass('input-validate-wrong');
                    NamePass = 1;
                    console.log(NamePass);
                } else {
                    $(this).addClass('input-validate-wrong').val('');
                    NamePass = 0;
                    console.log(NamePass);
                }
            }
            if ($('#txt-EPPhone').length > 0) {
                var PhoneValue = $('#txt-EPPhone').val();
                if (EmployeePhoneValidate(PhoneValue)) {
                    $(this).removeClass('input-validate-wrong');

                    PhonePass = 1;
                    console.log(PhonePass);
                } else {
                    $(this).addClass('input-validate-wrong').val('');

                    PhonePass = 0;
                    console.log(PhonePass);
                }
            }
            if ($('#txt-EPMail').length > 0) {
                var EmailValue = $('#txt-EPMail').val();
                if (EmployeeEmailValidate(EmailValue)) {
                    $(this).removeClass('input-validate-wrong');

                    MailPass = 1;
                    console.log(MailPass);
                } else {
                    $(this).addClass('input-validate-wrong').val('');

                    MailPass = 0;
                    console.log(MailPass);
                }
            }
        }
        $('#btnEPEditInfo').click(function () {
            if (NamePass == 1 && PhonePass == 1 && MailPass == 1) {
                return true;
            } else {
                alert('Personal Fail');
                event.preventDefault();
                return false;
            }
        })

    }
    function EditPasswordValidate() { // validate when user change personal password
        var OPWPass = 0;
        var NPWPass = 0;
        var CPWPass = 0;
        EPPasswordMatchingValidate();
        $('#txt-EPOldPassword').on('focusout', function () {
            var passwordvalue = $('#txt-EPOldPassword').val();
            if (EmployeePasswordValidate(passwordvalue)) {
                $('#txt-EPOldPassword-error').empty();
                OPWPass = 1;
            } else {
                $('#txt-EPOldPassword-error').empty();
                $('#txt-EPOldPassword').val('');
                $('#txt-EPOldPassword-error').css("color", "red").html('Mật khẩu không được có kí tự khoản trắng! Vui lòng nhập lại');
                OPWPass = 0;
            }
        })
        $('#txt-EPNewPassword').on('focusout', function () {
            var passwordvalue = $('#txt-EPNewPassword').val();
            if (EmployeePasswordValidate(passwordvalue)) {
                $('#txt-EPNewPassword-error').empty();
                NPWPass = 1;
            } else {
                $('#txt-EPNewPassword-error').empty();
                $('#txt-EPNewPassword').val('');
                $('#txt-EPNewPassword-error').css("color", "red").html('Mật khẩu không được có kí tự khoản trắng! Vui lòng nhập lại');
                NPWPass = 0;
            }
        })
        $('#txt-EPConFirmNewPassword').on('focusout', function () {
            var passwordvalue = $('#txt-EPConFirmNewPassword').val();
            if (EmployeePasswordValidate(passwordvalue)) {
                $('#txt-EPConFirmNewPassword-error').empty();
                CPWPass = 1;
            } else {
                $('#txt-EPConFirmNewPassword-error').empty();
                $('#txt-EPConFirmNewPassword').val('');
                $('#txt-EPConFirmNewPassword-error').css("color", "red").html('Mật khẩu không được có kí tự khoản trắng! Vui lòng nhập lại');
                CPWPass = 0;
            }
        })
        function EPPasswordMatchingValidate() {
            $('#txt-EPOldPassword,#txt-EPNewPassword').focusout(function () {// Comparing "Old Password" vs "New Password"
                var OldPW = $('#txt-EPOldPassword').val();
                var NewPw = $('#txt-EPNewPassword').val();
                if (OldPW == NewPw) {
                    $('#txt-EPOldPassword,#txt-EPNewPassword').toggleClass('input-validate-wrong', true);
                    $('#txt-EPNewPassword-error').css("color", "red").html('Mật khẩu Mới không được trùng mật khẩu Cũ');
                    OPWPass = 0;
                    NPWPass = 0;
                } else {
                    $('#txt-EPOldPassword,#txt-EPNewPassword').toggleClass('input-validate-wrong', false);
                    $('#txt-EPNewPassword-error').empty();
                    OPWPass = 1;
                    NPWPass = 1;
                }
            })
            $('#txt-EPConFirmNewPassword,#txt-EPNewPassword').focusout(function () { // Comparing "New Password" vs "Confirm New Password"
                var ConPW = $('#txt-EPConFirmNewPassword').val();
                var NewPW = $('#txt-EPNewPassword').val();
                if (ConPW == NewPW) {
                    $('#txt-EPConFirmNewPassword-error').css("color", "green").html('Mật khẩu Mới trùng khớp'); //message
                    $('#txt-EPConFirmNewPassword,#txt-EPNewPassword').toggleClass('input-validate-wrong', false);
                    NPWPass = 1;
                    CPWPass = 1;
                } else {
                    $('#txt-EPConFirmNewPassword-error').css("color", "red").html('Mật khẩu Mới không trùng khớp'); //message
                    $('#txt-EPConFirmNewPassword,#txt-EPNewPassword').toggleClass('input-validate-wrong', true);
                    NPWPass = 0;
                    CPWPass = 0;
                }
            });
        }
        $('#btnEPEditPassword').click(function () {
            if (OPWPass == 1 && NPWPass == 1 && CPWPass == 1) {
                //  $('#btnEPSubmit').prop('disabled',false);
                return true;
            } else {
                alert('Password Fail');
                //  $('#btnEPSubmit').prop('disabled',true);
                return false;
                event.preventDefault();

            }
        })
    }
    // validate name format //
    function EmployeeNameValidate(InputName) {
        var NameRegEx = /^([^-\s!@#$;%ˆ&*'()<>.?[{[}/^,:\\\]\~\`{}0-9])+[^-!@#$;%ˆ&*'()<>.?[{[}/^,:\\\]\~\`{}0-9]{1,35}$/;
        console.log(NameRegEx.test(InputName));
        return NameRegEx.test(InputName);
    }
    // validate phone number format //
    function EmployeePhoneValidate(InputPhone) {
        var PhoneRegEx = /^[\d]{2,13}$/;
        console.log(PhoneRegEx.test(InputPhone));
        return PhoneRegEx.test(InputPhone);
    }
    // validate email format //
    function EmployeeEmailValidate(InputEmail) {
        var EmailRegEx = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        console.log(EmailRegEx.test(InputEmail));
        return EmailRegEx.test(InputEmail);
    }
    // validate old password //
    function EmployeePasswordValidate(InputPassword) {
        var PasswordRegEx = /^(\S{1,})+$/;
        console.log(PasswordRegEx.test(InputPassword));
        return PasswordRegEx.test(InputPassword);
    }
}
// HNF-Employee-AddEmployee Validaion
function EmployeeAddValidation() {
    Validate();
    var ValidationPass = true;
    function Validate() {
        $("#InputName").change(function () {
            var ANameValue = $("#InputName").val();
            $("#InputName").removeClass('input-validate-wrong');
            if (ANameValidate(ANameValue)) {
                ValidationPass = true;
                CheckValidation(ValidationPass);
            } else {
                ValidationPass = false;
                CheckValidation(ValidationPass);
                $("#InputName").addClass('input-validate-wrong');
                $("#InputName").val('');
            }
        });
        $("#InputPhone").change(function () {
            var APhoneValue = $("#InputPhone").val();
            $("#InputPhone").removeClass('input-validate-wrong');
            if (APhoneValidate(APhoneValue)) {
                ValidationPass = true;
                CheckValidation(ValidationPass);
            } else {
                ValidationPass = false;
                CheckValidation(ValidationPass);
                $("#InputPhone").addClass('input-validate-wrong');
                $("#InputPhone").val('');

            }
        });
        $("#InputEmail").change(function () {
            var AEmailValue = $("#InputEmail").val();
            $("#InputEmail").removeClass('input-validate-wrong');
            if (AEmailValidate(AEmailValue)) {
                ValidationPass = true;
                CheckValidation(ValidationPass);
            } else {
                ValidationPass = false;
                CheckValidation(ValidationPass);
                $("#InputEmail").addClass('input-validate-wrong');
                $("#InputEmail").val('');

            }
        });
        $('#txt-input-password').change(function () {
            var APasswordValue = $('#txt-input-password').val();
            $('#txt-input-password').removeClass('input-validate-wrong');
            if (APasswordValidate(APasswordValue)) {
                ValidationPass = true;
                CheckValidation(ValidationPass);
            } else {
                ValidationPass = false;
                CheckValidation(ValidationPass);
                $('#txt-input-password').addClass('input-validate-wrong');
                $('#txt-input-password').val('');
            }
        });
        $('#txt-input-password-confirm').change(function () {
            var APasswordValue = $('#txt-input-password-confirm').val();
            $('#txt-input-password-confirm').removeClass('input-validate-wrong');
            if (APasswordValidate(APasswordValue)) {
                ValidationPass = true;
                CheckValidation(ValidationPass);
            } else {
                ValidationPass = false;
                CheckValidation(ValidationPass);
                $('#txt-input-password-confirm').addClass('input-validate-wrong');
                $('#txt-input-password-confirm').val('');
            }

        });
        $('#AddNewEmployeeBtn').click(function () {
            var Password = $('#txt-input-password').val();
            console.log(Password);
            var ConfirmPassword = $('#txt-input-password-confirm').val();
            console.log(ConfirmPassword);
            $('#txt-input-password').removeClass('input-validate-wrong');
            $('#txt-input-password-confirm').removeClass('input-validate-wrong');
            if (Password == ConfirmPassword) {
                ValidationPass = true;
                CheckValidation(ValidationPass);
                console.log('Password & ConfirmPassword: true');
                return true;
            } else {
                ValidationPass = false;
                CheckValidation(ValidationPass);
                $('#txt-input-password').addClass('input-validate-wrong');
                $('#txt-input-password-confirm').addClass('input-validate-wrong');
                return false;
            }
        })
    }
    // if validate fail this function will lock the submit button
    function CheckValidation(ValidationPass) {
        if (ValidationPass == true) {
            $('#AddNewEmployeeBtn').prop('disabled', false).removeClass('btn-secondary').addClass('btn-sucess');
        } else {
            $('#AddNewEmployeeBtn').prop('disabled', true).removeClass('btn-primary').addClass('btn-secondary');
        }
    }
    // validate name format //
    function ANameValidate(NameValue) {
        var ANameRegEx = /^([^-\s!@#$;%ˆ&*'()<>.?[{[}/^,:\\\]\~\`{}0-9])+[^-!@#$;%ˆ&*'()<>.?[{[}/^,:\\\]\~\`{}0-9]{1,35}$/;
        console.log('Aname = ' + ANameRegEx.test(NameValue));
        return ANameRegEx.test(NameValue);
    }
    // validate phone number format //
    function APhoneValidate(PhoneValue) {
        var APhoneRegEx = /^[\d]{2,13}$/;
        console.log('Aphone = ' + APhoneRegEx.test(PhoneValue));
        return APhoneRegEx.test(PhoneValue);
    }
    // validate email format //
    function AEmailValidate(EmailValue) {
        var AEmailRegEx = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        console.log('AEmail = ' + AEmailRegEx.test(EmailValue));
        return AEmailRegEx.test(EmailValue);
    }
    //   // validate old password //
    function APasswordValidate(PasswordValue) {
        var APasswordRegEx = /^.\S{1,}$/;
        console.log('APassword = ' + APasswordRegEx.test(PasswordValue));
        return APasswordRegEx.test(PasswordValue);
    }
}
// HNF-Customer-Detail Validation //
function CustomerDetailValidation() {
    Validate();

    function Validate() {
        PreloadValidation();
        var NamePass = false;
        var PhonePass = false;
        var EmailPass = false;
        $('#txt-CName').focusout(function () {
            var CustomerName = $('#txt-CName').val();
            $('#txt-CName').removeClass('input-validate-wrong');
            if (CName_Format_Validate(CustomerName)) {
                NamePass = true;
                CheckValidation();
            } else {
                NamePass = false;
                CheckValidation();
                $('#txt-CName').val('').addClass('input-validate-wrong');

            }
        });
        $('#txt-CPhone').focusout(function () {
            var CustomerPhone = $('#txt-CPhone').val();
            $('#txt-CPhone').removeClass('input-validate-wrong');
            if (CPhone_Format_Validate(CustomerPhone)) {
                PhonePass = true;
                CheckValidation();
            } else {
                PhonePass = false;
                CheckValidation();
                $('#txt-CPhone').val('').addClass('input-validate-wrong');
            }
        })
        $('#txt-CEmail').focusout(function () {
            var CustomerEmail = $('#txt-CEmail').val();
            $('#txt-CEmail').removeClass('input-validate-wrong');
            if (CEmail_Format_Validate(CustomerEmail)) {
                EmailPass = true;
                CheckValidation();
            } else {
                CheckValidation();
                EmailPass = false;
                $('#txt-CEmail').val('');
                $('#txt-CEmail').addClass('input-validate-wrong');
            }
        })
        $('#txt-CPrice').click(function () {
            var numcheck = $('#txt-CPrice').val();
            console.log("Price : " + numcheck);
            $('#txt-CPrice').val(AntiNegativeValue(numcheck));
        });
        $('#txt-CQuantity').click(function () {
            var numcheck = $('#txt-CQuantity').val();
            $('#txt-CQuantity').val(AntiNegativeValue(numcheck));
        });
        $('#txt-CPriceRange').click(function () {
            var numcheck = $('#txt-CPriceRange').val();
            $('#txt-CPriceRange').val(AntiNegativeValue(numcheck));
        })
        $('#txt-CCompany').click(function () {
            var txtValue = $('#txt-CCompany').val();
            if (COther_Format_Validate(txtValue) != true) {
                $('#txt-CCompany').val('');
            }
        })
        $('#txt-CJob').click(function () {
            var txtValue = $('#txt-CJob').val();
            if (COther_Format_Validate(txtValue) != true) {
                $('#txt-CJob').val('');
            }
        })
        $('#txt-CShirtBefore').click(function () {
            var txtValue = $('#txt-CShirtBefore').val();
            if (COther_Format_Validate(txtValue) != true) {
                $('#txt-CShirtBefore').val('');
            }
        })
        $('#txt-CFabricBefore').click(function () {
            var txtValue = $('#txt-CFabricBefore').val();
            if (COther_Format_Validate(txtValue) != true) {
                $('#txt-CFabricBefore').val('');
            }
        })
        $('#txt-CReview').click(function () {
            var txtValue = $('#txt-CReview').val();
            if (COther_Format_Validate(txtValue) != true) {
                $('#txt-CReview').val('');
            }
        })
        $('#txt-CCompanyBefore').click(function () {
            var txtValue = $('#txt-CCompanyBefore').val();
            if (COther_Format_Validate(txtValue) != true) {
                $('#txt-CCompanyBefore').val('');
            }
        })
        $('#txt-CShirtType').click(function () {
            var txtValue = $('#txt-CShirtType').val();
            if (COther_Format_Validate(txtValue) != true) {
                $('#txt-CShirtType').val('');
            }
        })
        $('#txt-CFabricType').click(function () {
            var txtValue = $('#txt-CFabricType').val();
            if (COther_Format_Validate(txtValue) != true) {
                $('#txt-CFabricType').val('');
            }
        })
        $('#txt-CGoal').click(function () {
            var txtValue = $('#txt-CGoal').val();
            if (COther_Format_Validate(txtValue) != true) {
                $('#txt-CGoal').val('');
            }
        })
        $('#txt-CPrint').click(function () {
            var txtValue = $('#txt-CPrint').val();
            if (COther_Format_Validate(txtValue) != true) {
                $('#txt-CPrint').val('');
            }
        })
        $('#txt-CGoal').click(function () {
            var txtValue = $('#txt-CGoal').val();
            if (COther_Format_Validate(txtValue) != true) {
                $('#txt-CGoal').val('');
            }
        })
        // pre-load validation
        function PreloadValidation() {
            if ($('#txt-CName').length > 0) {
                var CustomerName = $('#txt-CName').val();
                $('#txt-CName').removeClass('input-validate-wrong');
                if (CName_Format_Validate(CustomerName)) {
                    NamePass = true;
                    CheckValidation();
                } else {
                    NamePass = false;
                    CheckValidation();
                    $('#txt-CName').val('').addClass('input-validate-wrong');
                }
            }
            if ($('#txt-CPhone').length > 0) {
                var CustomerPhone = $('#txt-CPhone').val();
                $('#txt-CPhone').removeClass('input-validate-wrong');
                if (CPhone_Format_Validate(CustomerPhone)) {
                    PhonePass = true;
                    CheckValidation();
                } else {
                    PhonePass = false;
                    CheckValidation();
                    $('#txt-CPhone').val('').addClass('input-validate-wrong');
                }
            }
            if ($('#txt-CEmail').length > 0) {
                var CustomerEmail = $('#txt-CEmail').val();
                $('#txt-CEmail').removeClass('input-validate-wrong');
                if (CEmail_Format_Validate(CustomerEmail)) {
                    EmailPass = true;
                    CheckValidation();
                } else {
                    CheckValidation();
                    EmailPass = false;
                    $('#txt-CEmail').val('');
                    $('#txt-CEmail').addClass('input-validate-wrong');
                }
            }
            CheckValidation();
        }

        function CheckValidation() {
            if ((NamePass == true) && (PhonePass == true) && (EmailPass == true)) {
                $('#CustomerInfoSaveBtn').prop('disabled', false);
            } else {
                $('#CustomerInfoSaveBtn').prop('disabled', true);
            }
        }
    }
    // check name format
    function CName_Format_Validate(txtCustomerName) {
        var CustomerNameRegex = /^([^-\s!@#$;%ˆ&*'()<>.?[{[}/^,:\\\]\~\`{}0-9])+[^-!@#$;%ˆ&*'()<>.?[{[}/^,:\\\]\~\`{}0-9]{1,35}$/;
        console.log('Customer Name : ' + CustomerNameRegex.test(txtCustomerName));
        return CustomerNameRegex.test(txtCustomerName);
    }
    // check phone format
    function CPhone_Format_Validate(txtCustomerPhone) {
        var CustomerPhoneRegex = /^[\d]{2,13}$/;
        console.log('Customer Phone : ' + CustomerPhoneRegex.test(txtCustomerPhone));
        return CustomerPhoneRegex.test(txtCustomerPhone);
    }
    // check email format
    function CEmail_Format_Validate(txtCustomerEmail) {
        var CustomerEmail = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        console.log('Customer Email : ' + CustomerEmail.test(txtCustomerEmail));
        return CustomerEmail.test(txtCustomerEmail);
    }
    // check other field (without *)
    function COther_Format_Validate(txtField) {
        var CustomerOther = /^([^-!@#$;%ˆ&*'()<>.?[{[}/^,:\\\]\~\`]){0,35}$/;
        console.log(CustomerOther.test(txtField));
        return CustomerOther.test(txtField);
    }
}
// HNF-Customer-ContractDetail-DetailDesign //
function ContractDetailDesignValidation(form) {

    Validate();
    $('#formDetailDesign').submit(function (event) {
        Validate();
    });
    function Validate() { // this function will auto validate the input value everytime input has change
        var ColorPass = false;
        var ArmNeckPass = false;
        var FabricatePass = false;
        var FabricPass = false;
        PreloadValidation(); // check data that already available
        $('#txt_DD_Color').focusout(function () {
            var txtValue = $('#txt_DD_Color').val();
            if (COtherCL_Format_Validate(txtValue) == true) {
                $('#txt_DD_Color').toggleClass('input-validate-wrong', false);
                ColorPass = true;
            } else {
                $('#txt_DD_Color').val('').toggleClass('input-validate-wrong', true);
                ColorPass = false;
            }
        });
        $('#txt_DD_ArmNeck').focusout(function () {
            var txtValue = $('#txt_DD_ArmNeck').val();
            if (COtherCD_Format_Validate(txtValue) == true) {
                $('#txt_DD_ArmNeck').toggleClass('input-validate-wrong', false);
                ArmNeckPass = true;
            } else {
                $('#txt_DD_ArmNeck').val('').toggleClass('input-validate-wrong', true);
                ArmNeckPass = false;
            }
        });
        $('#txt_DD_Fabricate').focusout(function () {
            var txtValue = $('#txt_DD_Fabricate').val();
            if (COtherCD_Format_Validate(txtValue) == true) {
                $('#txt_DD_Fabricate').toggleClass('input-validate-wrong', false);
                FabricatePass = true;
            } else {
                $('#txt_DD_Fabricate').val('').toggleClass('input-validate-wrong', true);
                FabricatePass = false;
            }
        });
        $('#txt_DD_fabric').focusout(function () {
            var txtValue = $('#txt_DD_fabric').val();
            if (COtherCD_Format_Validate(txtValue) == true) {
                $('#txt_DD_fabric').toggleClass('input-validate-wrong', false);
                FabricPass = true;
            } else {
                $('#txt_DD_fabric').val('').toggleClass('input-validate-wrong', true);
                FabricPass = false;
            }
        });
        $('#txtMSmall,#txtMMedium,#txtMLarge,#txtMXLarge,#txtMXXLarge,#txtMXXXLarge,#txtFSmall,#txtFMedium,#txtFLarge,#txtFXLarge,#txtFXXLarge,#txtFXXXLarge').focusout(function () {
            // Male S
            var MSmall = Number($('#txtMSmall').val());
            // Male M
            var MMedium = Number($('#txtMMedium').val());
            // Male L
            var MLarge = Number($('#txtMLarge').val());
            // Male XL
            var MXLarge = Number($('#txtMXLarge').val());
            // Male XXL
            var MXXLarge = Number($('#txtMXXLarge').val());
            // Male XXXL
            var MXXXLarge = Number($('#txtMXXXLarge').val());
            // FeMale S
            var FSmall = Number($('#txtFSmall').val());
            // FeMale M
            var FMedium = Number($('#txtFMedium').val());
            // FeMale L
            var FLarge = Number($('#txtFLarge').val());
            // FeMale XL
            var FXLarge = Number($('#txtFXLarge').val());
            // FeMale XXL
            var FXXLarge = Number($('#txtFXXLarge').val());
            // FeMale XXXL
            var FXXXLarge = Number($('#txtFXXXLarge').val());
            DDesign_Total_Quantity_Validate(MSmall, MMedium, MLarge, MXLarge, MXXLarge, MXXXLarge, FSmall, FMedium, FLarge, FXLarge, FXXLarge, FXXXLarge);
        });
        function PreloadValidation() {
            if ($('#txt_DD_Color').length >= 0) {
                var txtValue = $('#txt_DD_Color').val();
                if (COtherCL_Format_Validate(txtValue) == true) {
                    $('#txt_DD_Color').toggleClass('input-validate-wrong', false);
                    ColorPass = true;
                } else {
                    $('#txt_DD_Color').val('').toggleClass('input-validate-wrong', true);
                    ColorPass = false;
                }
            }
            if ($('#txt_DD_ArmNeck').length >= 0) {
                var txtValue = $('#txt_DD_ArmNeck').val();
                if (COtherCD_Format_Validate(txtValue) == true) {
                    $('#txt_DD_ArmNeck').toggleClass('input-validate-wrong', false);
                    ArmNeckPass = true;
                } else {
                    $('#txt_DD_ArmNeck').val('').toggleClass('input-validate-wrong', true);
                    ArmNeckPass = false;
                }
            }
            if ($('#txt_DD_Fabricate').length >= 0) {
                var txtValue = $('#txt_DD_Fabricate').val();
                if (COtherCD_Format_Validate(txtValue) == true) {
                    $('#txt_DD_Fabricate').toggleClass('input-validate-wrong', false);
                    FabricatePass = true;
                } else {
                    $('#txt_DD_Fabricate').val('').toggleClass('input-validate-wrong', true);
                    FabricatePass = false;
                }
            }
            if ($('#txt_DD_fabric').length >= 0) {
                var txtValue = $('#txt_DD_fabric').val();
                if (COtherCD_Format_Validate(txtValue) == true) {
                    $('#txt_DD_fabric').toggleClass('input-validate-wrong', false);
                    FabricPass = true;
                } else {
                    $('#txt_DD_fabric').val('').toggleClass('input-validate-wrong', true);
                    FabricPass = false;
                }
            }
        }
        $('#DDSubmitBtn').click(function () {
            if ((ColorPass == true) && (FabricatePass == true) && (ArmNeckPass == true) && (FabricPass == true)) {
                return true;
            } else {
                console.log("ColorPass = " + ColorPass + " | ArmNeckPass = " + ArmNeckPass + "  | FabricatePass = " + FabricatePass + "  | FabricPass = " + FabricPass);
                event.preventDefault();
                return false;
            }
        })
    }
    // validate Color and Length
    function COtherCD_Format_Validate(txtField) {
        var CustomerOther = /^([^-!@#$;%ˆ&*'()<>.?[{[}/^,:\\\]\~\`]){0,30}$/;
        console.log("Other Field: " + CustomerOther.test(txtField));
        return CustomerOther.test(txtField);
    }
    // validate Color and Length
    function COtherCL_Format_Validate(txtField) {
        var CustomerOther = /^([^-!@#$;%ˆ&*'()<>.?[{[}/^,:\\\]\~\`]){0,15}$/;
        console.log("Color : " + CustomerOther.test(txtField));
        return CustomerOther.test(txtField);
    }
    // check the number type of Quantity Input
    function DDesign_Quantity_Validate(QuantityValue) {
        var QuantityRegex = /\d/;
        console.log('Quantity = ' + QuantityRegex.test(QuantityValue));
        return QuantityRegex.test(QuantityValue);
    }
    // check the total number type of size Input
    function DDesign_SizeQuantity_Validate(SizeQuantityValue) {
        var SizeQuantityRegex = /^[\d]{0,10}$/
        console.log('SizeQuantity = ' + SizeQuantityRegex.test(SizeQuantityValue));
        return SizeQuantityRegex.test(SizeQuantityValue);
    }
    // Check the number base on the Total quantity of the shirt and size input
    function DDesign_Total_Quantity_Validate(MSmall, MMedium, MLarge, MXLarge, MXXLarge, MXXXLarge, FSmall, FMedium, FLarge, FXLarge, FXXLarge, FXXXLarge) {
        var TotalMaleSize = MSmall + MMedium + MLarge + MXLarge + MXXLarge + MXXXLarge;
        var TotalFemaleSize = FSmall + FMedium + FLarge + FXLarge + FXXLarge + FXXXLarge;
        var TotalSize = TotalMaleSize + TotalFemaleSize;
        console.log('Total Size = ' + TotalSize);
        $('#txt_DD_Quantity').val(TotalSize);
    }
}
// ============= Statictis ============= //
// Test Chart
function DemoChart() {
    // pie chart
    var piechart = document.getElementById('PieChart');
}
$(document).ready(function () {
    Highcharts.setOptions({
        colors: ['#5cb85c', ' #d9534f', '#f0ad4e']
    });

    var success = parseFloat($('#contractsuccess').val());
    var failed = parseFloat($('#contractfailed').val());
    var waiting = parseFloat($('#contractwaiting').val());
    var year = parseFloat($('#contractyear').val());
    var month = parseFloat($('#contractmonth').val());

    //line chart
    var january = parseFloat($('#january').val());
    var february = parseFloat($('#february').val());
    var march = parseFloat($('#march').val());
    var april = parseFloat($('#april').val());
    var may = parseFloat($('#may').val());
    var june = parseFloat($('#june').val());
    var july = parseFloat($('#july').val());
    var august = parseFloat($('#august').val());
    var september = parseFloat($('#september').val());
    var october = parseFloat($('#october').val());
    var november = parseFloat($('#november').val());
    var december = parseFloat($('#december').val());
    var yearline = parseFloat($('#contractyearline').val());

    // Build the chart
    Highcharts.chart('container-1', {
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            type: 'pie'
        },
        title: {
            text: 'Tỷ lệ hợp đồng trong tháng 4, 2017'
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '<b>{point.name}</b>: {point.percentage:.1f} %',

                },
                showInLegend: true
            }
        },

        series: [{
            name: 'Tỷ lệ',
            colorByPoint: true,
            data: [{
                name: 'Thành công',
                y: success,
                sliced: true,
                selected: true
            }, {
                name: 'Thất bại',
                y: failed

            }, {
                name: 'Đang chờ phản hồi',
                y: waiting
            }]
        }]
    });
    Highcharts.setOptions({
        colors: ['#5bc0de']
    });
    Highcharts.chart('container-2', {
        chart: {
            type: 'line'
        },
        title: {
            text: 'Tổng số hợp đồng trong năm'
        },
        subtitle: {
            text: ''
        },
        xAxis: {
            categories: ['Tháng 1', 'Tháng 2', 'Tháng 3', 'Tháng 4', 'Tháng 5', 'Tháng 6', 'Tháng 7', 'Tháng 8', 'Tháng 9', 'Tháng 10', 'Tháng 11', 'Tháng 12']
        },
        yAxis: {
            title: {
                text: 'Số lượng hợp đồng'
            }
        },
        plotOptions: {
            line: {
                dataLabels: {
                    enabled: true
                },
                enableMouseTracking: true
            }
        },
        series: [{
            name: 'Số hợp đồng',
            data: [january, february, march, april, may, june, july, august, september, october, november, december]
        }]
    });
});
