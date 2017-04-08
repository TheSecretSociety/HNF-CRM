// ***************************************************** //
// *                ACTIVE ALL FUNCTION                * //
// ***************************************************** //
// $(document).ready() only one so all function will be calling here
$(document).ready(function () {
    LoginValidation();
    EmployeePersonalValidation();
    CustomerDetailValidation();
    ContractDetailDesignValidation();
    EmployeeAddValidation();

    ClearButton();
    DeleteButtonWarning();
    ProductionProgressBar();
    DatetimePicker();

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
        var DeleteState = confirm("Bạn có chắc chắn muốn xóa?");
        if (DeleteState == true) {
            alert("Xóa Thành Công!");
            return true;
        } else {
            alert("Đã Hủy Lệnh Xóa!");
            return false;
        }
    }
}

// Production line Bar animation //
function ProductionProgressBar() {
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

// Datetimepicker //
function DatetimePicker() {
    $('#sandbox-container .input-group.date').datepicker({
        weekStart: 1,
        orientation: "bottom auto",
        autoclose: true,
        todayHighlight: true,
        format: "dd/mm/yyyy",
        language: "vi"
    });
    $('#sandbox-container .input-daterange').datepicker({
        format: "dd/mm/yyyy",
        weekStart: 1,
        language: "vi",
        orientation: "bottom auto",
        keyboardNavigation: false,
        autoclose: true,
        todayHighlight: true
    });
}

// Alert //


// ----------------------------------------------------- //
// --------------------- VALIDATION -------------------- //
// ----------------------------------------------------- //
// HNF-Login Validation //
function LoginValidation() {
    Validate();
    // keyboard input listener (Enter Key)
    function KeyboardInput() {
        $("#TxtLoginPassword").keyup(function (event) {
            if (event.keyCode == 13) {
                $("#LoginButton").click();
            }
        });
        $("#TxtLoginID").keyup(function (event) {
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
                // náº¿u Ä‘Ãºng controller sáº½ thá»±c hiá»‡n
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
                // náº¿u Ä‘Ãºng controller sáº½ thá»±c hiá»‡n
                return true;
            } else {
                $('.PasswordError').append('<small style="color:white;">Password không thể có khoảng trắng!');
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
function EmployeePersonalValidation() {
    // trigger button
    $('#Personal-Update-Button').click(function () {
        EmployeePersonalValidate();
    });
    // check validtion (calling other function)
    function EmployeePersonalValidate(e) {
        var NameValue = $('#InputName').val();
        var PhoneValue = $('#InputPhone').val();
        var EmailValue = $('#InputEmail').val();
        var OldPasswordValue = $('#txt-old-password').val();
        var NewPasswordValue = $('#txt-new-password').val();
        // check for validate when edit employee information
        var check = 0;
        if (EmployeeNameValidate(NameValue)) {
        } else {
            check++;
        }

        if (EmployeePhoneValidate(PhoneValue)) {
        } else {
            check++;
        }
        if (EmployeeEmailValidate(EmailValue)) {
        } else {
            check++;
        }

        if (check == 0) {
            alert("Edit Successfully");
        } else if (check != 0) {
            alert("Edit Fail");
        }
    };
    // validate name format //
    function EmployeeNameValidate(InputName) {
        var NameRegEx = /^.[^.!@#$%^&*()_+-=]{0,35}$/;
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
    function EmployeeOldPasswordValidate(InputOldPassword, InputNewPassword) {
        var OldPasswordRegEx = /^.\S{1,}$/;
        console.log(OldPasswordRegEx.test(InputOldPassword, InputNewPassword));
        return OldPasswordRegEx.test(InputOldPassword, InputNewPassword);
    }
}

// HNF-Employee-AddEmployee Validaion
function EmployeeAddValidation() {
    Validate();
    function Validate() {
        $("#InputName").change(function () {
            var ANameValue = $("#InputName").val();
            $("#InputName").removeClass("bg-warning");
            if (ANameValidate(ANameValue)) {
            } else {
                $("#InputName").addClass("bg-warning");
                $("#InputName").val('');
            }
        });
        $("#InputPhone").change(function () {
            var APhoneValue = $("#InputPhone").val();
            $("#InputPhone").removeClass("bg-warning");
            if (APhoneValidate(APhoneValue)) {
            } else {
                $("#InputPhone").addClass("bg-warning");
                $("#InputPhone").val('');

            }
        });
        $("#InputEmail").change(function () {
            var AEmailValue = $("#InputEmail").val();
            $("#InputEmail").removeClass("bg-warning");
            if (AEmailValidate(AEmailValue)) {
            } else {
                $("#InputEmail").addClass("bg-warning");
                $("#InputEmail").val('');

            }
        });
        $('#txt-input-password').change(function () {
            var APasswordValue = $('#txt-input-password').val();
            $('#txt-input-password').removeClass("bg-warning");
            if (APasswordValidate(APasswordValue)) {
            } else {
                $('#txt-input-password').addClass("bg-warning");
                $('#txt-input-password').val('');
            }
        });
        $('#txt-input-password-confirm').change(function () {
            var APasswordValue = $('#txt-input-password-confirm').val();
            $('#txt-input-password-confirm').removeClass("bg-warning");
            if (APasswordValidate(APasswordValue)) {
            } else {
                $('#txt-input-password-confirm').addClass("bg-warning");
                $('#txt-input-password-confirm').val('');
            }

        });
        $('#AddNewEmployeeBtn').click(function () {
            var Password = $('#txt-input-password').val();
            console.log(Password);
            var ConfirmPassword = $('#txt-input-password-confirm').val();
            console.log(ConfirmPassword);
            $('#txt-input-password').removeClass('bg-warning');
            $('#txt-input-password-confirm').removeClass('bg-warning');
            if (Password == ConfirmPassword) {
                console.log('Password & ConfirmPassword: true');
                return true;
            } else {
                $('#txt-input-password').addClass('bg-warning');
                $('#txt-input-password-confirm').addClass('bg-warning');
                return false;
            }
        })
    }

    // validate name format //
    function ANameValidate(NameValue) {
        var ANameRegEx = /^.{0,35}[^!@#.$%^&*()_+-=]$/;
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
        $('#txt-CName').change(function () {
            var CustomerName = $('#txt-CName').val();
            $('#txt-CName').removeClass('bg-warning');
            if (CName_Format_Validate(CustomerName)) {
            } else {
                $('#txt-CName').addClass('bg-warning');
            }
        })
        $('#txt-CPhone').change(function () {
            var CustomerPhone = $('#txt-CPhone').val();
            $('#txt-CPhone').removeClass('bg-warning');
            if (CPhone_Format_Validate(CustomerPhone)) {
            } else {
                $('#txt-CPhone').addClass('bg-warning');
            }
        })
        $('#txt-CEmail').change(function () {
            var CustomerEmail = $('#txt-CEmail').val();
            $('#txt-CEmail').removeClass('bg-warning');
            if (CEmail_Format_Validate(CustomerEmail)) {
            } else {
                $('#txt-CEmail').addClass('bg-warning');
            }
        })
        $('#txt-CPrice').change(function () {
            var numcheck = $('#txt-CPrice').val();
            console.log("Price : " + numcheck);
            $('#txt-CPrice').val(AntiNegativeValue(numcheck));
        });
        $('#txt-CQuantity').change(function () {
            var numcheck = $('#txt-CQuantity').val();
            $('#txt-CQuantity').val(AntiNegativeValue(numcheck));
        });
        $('#txt-CPriceRange').change(function () {
            var numcheck = $('#txt-CPriceRange').val();
            $('#txt-CPriceRange').val(AntiNegativeValue(numcheck));
        })
    }
    function CName_Format_Validate(txtCustomerName) {
        var CustomerNameRegex = /^.[^.!@#$%^&*()_+-=]{0,35}$/;
        console.log('Customer Name : ' + CustomerNameRegex.test(txtCustomerName));
        return CustomerNameRegex.test(txtCustomerName);
    }
    function CPhone_Format_Validate(txtCustomerPhone) {
        var CustomerPhoneRegex = /^[\d]{2,13}$/;
        console.log('Customer Phone : ' + CustomerPhoneRegex.test(txtCustomerPhone));
        return CustomerPhoneRegex.test(txtCustomerPhone);
    }
    function CEmail_Format_Validate(txtCustomerEmail) {
        var CustomerEmail = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        console.log('Customer Email : ' + CustomerEmail.test(txtCustomerEmail));
        return CustomerEmail.test(txtCustomerEmail);
    }
    // make negative number into positive
    function AntiNegativeValue(num) {
        if (num < 0) {
            num = -num;
            return num;
        }
        return num;
    }
}

// HNF-Customer-ContractDetail-DetailDesign //
function ContractDetailDesignValidation() {
    Validate();
    function Validate() { // this function will auto validate the input value everytime input has change
        // Quantity Validate
        $("#txt_DD_Quantity").change(function TotalQuantityCheck() {
            var QuantityValue = Number($("#txt_DD_Quantity").val());
            $("#txt_DD_Quantity").val(AntiNegativeValue(QuantityValue)); // check negative value and return the value back to the input
            var Result = DDesign_Quantity_Validate(QuantityValue);
            if (Result != true) {
                $("#txt_DD_Quantity").addClass("bg-danger");
                $("#txt_DD_Quantity").val('');
                // warning timeout
                window.setTimeout(function () {
                    $("#txt_DD_Quantity").removeClass("bg-danger");
                }, 1000);
            }
        });
        // Negative size converter
        $('input').change(function MakePositive() {
            // Male S
            var MSmall = $('#txtMSmall').val();
            $('#txtMSmall').val(AntiNegativeValue(MSmall));
            // Male M
            var MMedium = $('#txtMMedium').val();
            $('#txtMMedium').val(AntiNegativeValue(MMedium));
            // Male L
            var MLarge = $('#txtMLarge').val();
            $('#txtMLarge').val(AntiNegativeValue(MLarge));
            // Male XL
            var MXLarge = $('#txtMXLarge').val();
            $('#txtMXLarge').val(AntiNegativeValue(MXLarge));
            // Male XXL
            var MXXLarge = $('#txtMXXLarge').val();
            $('#txtMXXLarge').val(AntiNegativeValue(MXXLarge));
            // Male XXXL
            var MXXXLarge = $('#txtMXXXLarge').val();
            $('#txtMXXXLarge').val(AntiNegativeValue(MXXXLarge));

            // FeMale S
            var FSmall = $('#txtFSmall').val();
            $('#txtFSmall').val(AntiNegativeValue(FSmall));
            // FeMale M
            var FMedium = $('#txtFMedium').val();
            $('#txtFMedium').val(AntiNegativeValue(FMedium));
            // FeMale L
            var FLarge = $('#txtFLarge').val();
            $('#txtFLarge').val(AntiNegativeValue(FLarge));
            // FeMale XL
            var FXLarge = $('#txtFXLarge').val();
            $('#txtFXLarge').val(AntiNegativeValue(FXLarge));
            // FeMale XXL
            var FXXLarge = $('#txtFXXLarge').val();
            $('#txtFXXLarge').val(AntiNegativeValue(FXXLarge));
            // FeMale XXXL
            var FXXXLarge = $('#txtFXXXLarge').val();
            $('#txtFXXXLarge').val(AntiNegativeValue(FXXXLarge));
        });
        // Compare total shirt with total shirt size
        $('#DDSubmitBtn').click(function CompareQuantity() { //only validation when "Submit Button" is click
            var MSmall = Number($('#txtMSmall').val());
            var MMedium = Number($('#txtMMedium').val());
            var MLarge = Number($('#txtMLarge').val());
            var MXLarge = Number($('#txtMXLarge').val());
            var MXXLarge = Number($('#txtMXXLarge').val());
            var MXXXLarge = Number($('#txtMXXXLarge').val());
            var FSmall = Number($('#txtFSmall').val());
            var FMedium = Number($('#txtFMedium').val());
            var FLarge = Number($('#txtFLarge').val());
            var FXLarge = Number($('#txtFXLarge').val());
            var FXXLarge = Number($('#txtFXXLarge').val());
            var FXXXLarge = Number($('#txtFXXXLarge').val());
            var TotalShirt = Number($('#txt_DD_Quantity').val());
            DDesign_Total_Quantity_Validate(MSmall, MMedium, MLarge, MXLarge, MXXLarge, MXXXLarge, FSmall, FMedium, FLarge, FXLarge, FXXLarge, FXXXLarge, TotalShirt);
        })
    }
    // make negative number into positive
    function AntiNegativeValue(num) {
        if (num < 0) {
            num = -num;
            return num;
        }
        return num;
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
    function DDesign_Total_Quantity_Validate(MSmall, MMedium, MLarge, MXLarge, MXXLarge, MXXXLarge, FSmall, FMedium, FLarge, FXLarge, FXXLarge, FXXXLarge, TotalShirt) {

        var TotalMaleSize = MSmall + MMedium + MLarge + MXLarge + MXXLarge + MXXXLarge;
        console.log('Total Male Size = ' + TotalMaleSize);

        var TotalFemaleSize = FSmall + FMedium + FLarge + FXLarge + FXXLarge + FXXXLarge;
        console.log('Total Female Size = ' + TotalFemaleSize);

        var TotalSize = TotalMaleSize + TotalFemaleSize;
        console.log('Total Size = ' + TotalSize);
        if (TotalSize == TotalShirt) {
            console.log('equal = ' + true);
            return true;
        } else {
            console.log('equal = ' + false);
            $(".table-input").addClass('bg-danger');
            window.setTimeout(function () {
                $(".table-input").removeClass('bg-danger');
            }, 1000);
            return false;
        }
    }
}


// ============= Statictis ============= //
// Test Chart

function DemoChart() {
    // bar chart
    var barchart = document.getElementById("BarChart");
    var myChart = new Chart(barchart, {
        type: 'bar',
        data:
        {
            labels: ["Red", "Blue", "Yellow", "Green", "Purple", "Orange"],
            datasets:
            [
              {
                  label: '1',
                  data: [Math.random(), Math.random(), Math.random(), Math.random(), Math.random(), Math.random(), Math.random()],
                  backgroundColor:
                  [
                      'rgba(255, 99, 132, 0.2)',
                      'rgba(54, 162, 235, 0.2)',
                      'rgba(255, 206, 86, 0.2)',
                      'rgba(75, 192, 192, 0.2)',
                      'rgba(153, 102, 255, 0.2)',
                      'rgba(255, 159, 64, 0.2)'
                  ],
                  borderColor:
                  [
                      'rgba(255,99,132,1)',
                      'rgba(54, 162, 235, 1)',
                      'rgba(255, 206, 86, 1)',
                      'rgba(75, 192, 192, 1)',
                      'rgba(153, 102, 255, 1)',
                      'rgba(255, 159, 64, 1)'
                  ],
                  borderWidth: 1
              },

            ]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
    // line chart
    var linechart = document.getElementById('LineChart');
    var LineChartData = new Chart(linechart, {
        type: 'line',
        data: {
            labels: ["January", "February", "March", "April", "May", "June", "July"],
            datasets:
              [
                {
                    label: "Doanh Sá»‘ BÃ¡n HÃ ng",
                    fill: true,
                    lineTension: 0.1,
                    backgroundColor: "rgba(75,192,192,0.4)",
                    borderColor: "rgba(75,192,192,1)",
                    borderCapStyle: 'butt',
                    borderDash: [],
                    borderDashOffset: 0.0,
                    borderJoinStyle: 'miter',
                    pointBorderColor: "rgba(75,192,192,1)",
                    pointBackgroundColor: "#fff",
                    pointBorderWidth: 2,
                    pointHoverRadius: 5,
                    pointHoverBackgroundColor: "rgba(75,192,192,1)",
                    pointHoverBorderColor: "rgba(220,220,220,1)",
                    pointHoverBorderWidth: 2,
                    pointRadius: 5,
                    pointHitRadius: 10,
                    data: [Math.random(), Math.random(), Math.random(), Math.random(), Math.random(), Math.random(), Math.random()],
                    spanGaps: false,
                }
              ]
        },
        options: {

            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
    // pie chart
    var piechart = document.getElementById('PieChart');
    var PieChartData = new Chart(piechart, {
        type: 'pie',
        data: {
            labels: [
              "Red",
              "Blue",
              "Yellow"
            ],
            datasets:
              [
                {
                    data: [Math.round(Math.random() * 100), Math.round(Math.random() * 100), Math.round(Math.random() * 100)],
                    backgroundColor: [
                        "#FF6384",
                        "#36A2EB",
                        "#FFCE56"
                    ],
                    hoverBackgroundColor: [
                        "#FF6384",
                        "#36A2EB",
                        "#FFCE56"
                    ]
                }
              ]
        },
    });
}
