// ***************************************************** //
// *                ACTIVE ALL FUNCTION                * //
// ***************************************************** //
  // $(document).ready() type one only, so all functions will be calling here
    $(document).ready(function() {
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
    function ClearButton(){
        // script for Cancle Buttons
        $("#Cancle-Button").click(function(){
          $("input, textarea, select").val('').prop('checked', false);
          $("option").prop("selected", function(){return this.defaultSelected;});
        });
      }

    // Delete Button Warning //
    function DeleteButtonWarning() {
      $('#EmployeeDeleteBtn').click(function() {
        DeleteWarning();
      })
      $('#CustomerDetailDeleteBtn').click(function() {
        DeleteWarning();
      })
      $('#CustomerDeleteBtn').click(function(){
        DeleteWarning();
      });
      function DeleteWarning() {
        var DeleteState = confirm("Bạn Có Chắc Chắn Muốn Xoá ?");
        if (DeleteState == true) {
          alert("Xoá Thành Công!");
          return true;
        }else{
          alert("Đã Huỷ Lệnh Xoá");
          return false;
        }
      }
    }

    // Production line Bar animation //
    function ProductionProgressBar(){
      if ($("#check1:checked").length>0) {
        $('#progress1').css('width', '100%').css('transition', '0.5s')
        $('#progress2').css('width', '50%').css('transition','0.5s').css('transition-delay','0.1s')
        $("#check2").prop("disabled", false);
      }
      if($("#check2:checked").length>0) {
        $('#progress2').css('width', '100%').css('transition', '0.5s')
        $('#progress3').css('width', '50%').css('transition','0.5s').css('transition-delay','0.1s')
        $("#check1").prop("disabled", true);
        $("#check3").prop("disabled", false);
      }
      if($("#check3:checked").length>0) {
        $('#progress3').css('width', '100%').css('transition', '0.5s')
        $('#progress4').css('width', '50%').css('transition','0.5s').css('transition-delay','0.1s')
        $("#check2").prop("disabled", true);
        $("#check4").prop("disabled", false);
      }
      if($("#check4:checked").length>0) {
        $('#progress4').css('width', '100%').css('transition', '0.5s')
        $('#progress5').css('width', '50%').css('transition','0.5s').css('transition-delay','0.1s')
        $("#check3").prop("disabled", true);
        $("#check5").prop("disabled", false);
      }
      if($("#check5:checked").length>0) {
        $('#progress5').css('width', '100%').css('transition', '0.5s')
        $('#progress6').css('width', '50%').css('transition','0.5s').css('transition-delay','0.1s')
        $("#check4").prop("disabled", true);
        $("#check6").prop("disabled", false);
      }
      if($("#check6:checked").length>0) {
        $('#progress6').css('width', '100%').css('transition', '0.5s')
        $("#check5").prop("disabled", true);
      }
      $('#check1').change(function () {
          // this will contain a reference to the checkbox
          if (this.checked) {
              // the checkbox1 is now checked
              $('#progress1').css('width', '100%').css('transition', '0.5s')
              $('#progress2').css('width', '50%').css('transition','0.5s').css('transition-delay','0.1s')
              $("#check2").prop("disabled", false);
          } else {
              // the checkbox1 is now no longer checked
              $('#progress1').css('width', '50%').css('transition', '0.5s').css('transition-delay','0.1s')
              $('#progress2').css('width', '0%').css('transition', '0.5s')
              $("#check2").prop("disabled", true);

          }
      });
      $('#check2').change(function () {
            // this will contain a reference to the checkbox
            if (this.checked) {
                // the checkbox2 is now checked
                $('#progress2').css('width', '100%').css('transition', '0.5s')
                $('#progress3').css('width', '50%').css('transition','0.5s').css('transition-delay','0.1s')
                $("#check1").prop("disabled", true);
                $("#check3").prop("disabled", false);
            } else {
                // the checkbox2 is now no longer checked
                $('#progress2').css('width', '50%').css('transition', '0.5s').css('transition-delay','0.1s')
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
              $('#progress4').css('width', '50%').css('transition','0.5s').css('transition-delay','0.1s')
              $("#check2").prop("disabled", true);
              $("#check4").prop("disabled", false);
          } else {
              // the checkbox3 is now no longer checked
              $('#progress3').css('width', '50%').css('transition', '0.5s').css('transition-delay','0.1s')
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
                $('#progress5').css('width', '50%').css('transition','0.5s').css('transition-delay','0.1s')
                $("#check3").prop("disabled", true);
                $("#check5").prop("disabled", false);
            } else {
                // the checkbox4 is now no longer checked
                $('#progress4').css('width', '50%').css('transition', '0.5s').css('transition-delay','0.1s')
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
              $('#progress6').css('width', '50%').css('transition','0.5s').css('transition-delay','0.1s')
              $("#check4").prop("disabled", true);
              $("#check6").prop("disabled", false);
          } else {
              // the checkbox5 is now no longer checked
              $('#progress5').css('width', '50%').css('transition', '0.5s').css('transition-delay','0.1s')
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
    function DatetimePicker(){
      $('#sandbox-container .input-group.date').datepicker({
        weekStart: 1,
        orientation: "bottom auto",
        autoclose: true,
        todayHighlight: true,
        format: "dd/mm/yyyy",
        language:"vi"
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
    function LoginValidation(){
      Validate();
      // keyboard input listener (Enter Key)
      function KeyboardInput() {
        $("#TxtLoginPassword").change(function(event){
          if(event.keyCode == 13){
              $("#LoginButton").click();
          }
        });
        $("#TxtLoginID").change(function(event){
          if(event.keyCode == 13){
              $("#LoginButton").click();
          }
        });
      }
      // calling validate funtions
      function Validate() {
        $('#TxtLoginID').change(function IDValidation(){
          var UsernameValue = $('#TxtLoginID').val();
          $('.IDError').empty();
          if (LoginUsernameValidate(UsernameValue)) {
            $('.IDError').empty();
            // nếu đúng controller sẽ thực hiện
            return true;
          }else{
            $('.IDError').append('<small style="color:white;">Vui lòng nhập lại Email!</small>');
            return false;
          }
        });
        $('#TxtLoginPassword').change(function PasswordValidation(){
          var PasswordValue = $('#TxtLoginPassword').val();
          $('.PasswordError').empty();
          if (LoginPasswordValidate(PasswordValue)) {
            $('.PasswordError').empty();
            // nếu đúng controller sẽ thực hiện
            return true;
          }else{
            $('.PasswordError').append('<small style="color:white;">Password không được có khoản trắng!');
            return false;
          }
        });
      }
      // validate email format
      function LoginUsernameValidate(TxtLoginID){
        var EmailRegEx= /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        console.log('Email ID :' + EmailRegEx.test(TxtLoginID));
        return EmailRegEx.test(TxtLoginID);
      }
      // validate password format
      function LoginPasswordValidate(TxtLoginPassword) {
        var PasswordRegEx= /^.\S{1,}$/;
        console.log('Password :' + PasswordRegEx.test(TxtLoginPassword));
        return PasswordRegEx.test(TxtLoginPassword);
      }
    }
    // HNF-Employee-Personal Validation //
    function EmployeePersonalValidation(form){
      Validate();
      $('#EmployeePersonalInformationForm').submit(function(event) {
        Validate();
      })
      function Validate() { // calling validate functions
        var NamePass = 0;
        var PhonePass = 0;
        var MailPass = 0;
        var OPWPass = 0;
        var NPWPass = 0;
        var CPWPass = 0;
        $('#txt-EPName').focusout(function() {
          var NameValue = $('#txt-EPName').val();
          if (EmployeeNameValidate(NameValue)){
            $(this).removeClass('input-validate-wrong');
            NamePass = 1;
          }else{
            $(this).addClass('input-validate-wrong').val('');
            NamePass = 0;
          }
        })
        $('#txt-EPPhone').focusout(function() {
          var PhoneValue = $(this).val();
          if (EmployeePhoneValidate(PhoneValue)) {
            $(this).removeClass('input-validate-wrong');
            PhonePass = 1;
          }else{
            $(this).addClass('input-validate-wrong').val('');
            PhonePass = 0;
          }
        })
        $('#txt-EPMail').focusout(function() {
          var EmailValue = $(this).val();
          if (EmployeeEmailValidate(EmailValue)) {
            $(this).removeClass('input-validate-wrong');
            MailPass = 1;
          }else{
            $(this).addClass('input-validate-wrong').val('');
            MailPass = 0;
          }
        })
        $('#txt-EPOldPassword').on('focusout',function(){
          var passwordvalue = $('#txt-EPOldPassword').val();
          if (EmployeePasswordValidate(passwordvalue)) {
            $('#txt-EPOldPassword-error').empty();
            OPWPass = 1;
          }else{
            $('#txt-EPOldPassword-error').empty();
            $('#txt-EPOldPassword').val('');
            $('#txt-EPOldPassword-error').css("color","red").html('Mật khẩu không được có kí tự khoản trắng! Vui lòng nhập lại');
            OPWPass = 0;
          }
        })
        $('#txt-EPNewPassword').on('focusout',function(){
          var passwordvalue = $('#txt-EPNewPassword').val();
          if (EmployeePasswordValidate(passwordvalue)) {
            $('#txt-EPNewPassword-error').empty();
            NPWPass = 1;
          }else{
            $('#txt-EPNewPassword-error').empty();
            $('#txt-EPNewPassword').val('');
            $('#txt-EPNewPassword-error').css("color","red").html('Mật khẩu không được có kí tự khoản trắng! Vui lòng nhập lại');
            NPWPass = 0;
          }
        })
        $('#txt-EPConFirmNewPassword').on('focusout',function(){
          var passwordvalue = $('#txt-EPConFirmNewPassword').val();
          if (EmployeePasswordValidate(passwordvalue)) {
            $('#txt-EPConFirmNewPassword-error').empty();
            CPWPass = 1;
          }else{
            $('#txt-EPConFirmNewPassword-error').empty();
            $('#txt-EPConFirmNewPassword').val('');
            $('#txt-EPConFirmNewPassword-error').css("color","red").html('Mật khẩu không được có kí tự khoản trắng! Vui lòng nhập lại');
            CPWPass = 0;
          }
        })
        $('#txt-EPOldPassword,#txt-EPNewPassword').focusout(function() {// Comparing "Old Password" vs "New Password"
          var OldPW = $('#txt-EPOldPassword').val();
          var NewPw = $('#txt-EPNewPassword').val();
          if (OldPW == NewPw) {
            $('#txt-EPOldPassword,#txt-EPNewPassword').toggleClass('input-validate-wrong',true);
            $('#txt-EPNewPassword-error').css("color","red").html('Mật khẩu Mới không được trùng mật khẩu Cũ');
            OPWPass = 0;
            NPWPass = 0;
          }else{
            $('#txt-EPOldPassword,#txt-EPNewPassword').toggleClass('input-validate-wrong',false);
            $('#txt-EPNewPassword-error').empty();
            OPWPass = 1;
            NPWPass = 1;
          }
        })
        $('#txt-EPConFirmNewPassword,#txt-EPNewPassword').focusout(function() { // Comparing "New Password" vs "Confirm New Password"
          var ConPW = $('#txt-EPConFirmNewPassword').val();
          var NewPW = $('#txt-EPNewPassword').val();
          if (ConPW == NewPW) {
            $('#txt-EPConFirmNewPassword-error').css("color","green").html('Mật khẩu Mới trùng khớp'); //message
            $('#txt-EPConFirmNewPassword,#txt-EPNewPassword').toggleClass('input-validate-wrong', false);
            NPWPass = 1;
            CPWPass = 1;
          }else{
            $('#txt-EPConFirmNewPassword-error').css("color","red").html('Mật khẩu Mới không trùng khớp'); //message
            $('#txt-EPConFirmNewPassword,#txt-EPNewPassword').toggleClass('input-validate-wrong', true);
            NPWPass = 0;
            CPWPass = 0;
          }
        });
        // btnEPSubmit
        // #txt-EPName,#txt-EPPhone,#txt-EPMail,#txt-EPOldPassword,#txt-EPNewPassword,#txt-EPConFirmNewPassword
        $('#btnEPSubmit').click(function() {
          if (NamePass == 1 && PhonePass == 1 && MailPass == 1 && OPWPass == 1 && NPWPass == 1 && CPWPass == 1) {
            return true;
          }else{
            alert('fail');
             event.preventDefault();
             return false;
          }
        })
      }
      function EmployeeNameValidate(InputName){
        var NameRegEx= /^([^-!@#$;%ˆ&*'()<>.?[{[}/^,:\\\]\~\`{}0-9])+$/;
        console.log(NameRegEx.test(InputName));
        return NameRegEx.test(InputName);
      }
      // validate phone number format //
      function EmployeePhoneValidate(InputPhone){
        var PhoneRegEx= /^[\d]{2,13}$/;
        console.log(PhoneRegEx.test(InputPhone));
        return PhoneRegEx.test(InputPhone);
      }
      // validate email format //
      function EmployeeEmailValidate(InputEmail){
        var EmailRegEx= /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        console.log(EmailRegEx.test(InputEmail));
        return EmailRegEx.test(InputEmail);
      }
      // validate old password //
      function EmployeePasswordValidate(InputPassword){
        var PasswordRegEx= /^(\S{1,})+$/;
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
          $("#InputName").removeClass("bg-warning");
          if(ANameValidate(ANameValue)){
            ValidationPass = true;
            CheckValidation(ValidationPass);
          }else{
            ValidationPass = false;
            CheckValidation(ValidationPass);
            $("#InputName").addClass("bg-warning");
            $("#InputName").val('');
          }
        });
        $("#InputPhone").change(function () {
          var APhoneValue = $("#InputPhone").val();
          $("#InputPhone").removeClass("bg-warning");
          if(APhoneValidate(APhoneValue)){
            ValidationPass = true;
            CheckValidation(ValidationPass);
          }else{
            ValidationPass = false;
            CheckValidation(ValidationPass);
            $("#InputPhone").addClass("bg-warning");
            $("#InputPhone").val('');

          }
        });
        $("#InputEmail").change(function () {
          var AEmailValue = $("#InputEmail").val();
          $("#InputEmail").removeClass("bg-warning");
          if(AEmailValidate(AEmailValue)){
            ValidationPass = true;
            CheckValidation(ValidationPass);
          }else{
            ValidationPass = false;
            CheckValidation(ValidationPass);
            $("#InputEmail").addClass("bg-warning");
            $("#InputEmail").val('');

          }
        });
        $('#txt-input-password').change(function(){
          var APasswordValue = $('#txt-input-password').val();
          $('#txt-input-password').removeClass("bg-warning");
          if(APasswordValidate(APasswordValue)){
            ValidationPass = true;
            CheckValidation(ValidationPass);
          }else {
            ValidationPass = false;
            CheckValidation(ValidationPass);
            $('#txt-input-password').addClass("bg-warning");
            $('#txt-input-password').val('');
          }
        });
        $('#txt-input-password-confirm').change(function(){
          var APasswordValue = $('#txt-input-password-confirm').val();
          $('#txt-input-password-confirm').removeClass("bg-warning");
          if(APasswordValidate(APasswordValue)){
            ValidationPass = true;
            CheckValidation(ValidationPass);
          }else {
            ValidationPass = false;
            CheckValidation(ValidationPass);
            $('#txt-input-password-confirm').addClass("bg-warning");
            $('#txt-input-password-confirm').val('');
          }

        });
        $('#AddNewEmployeeBtn').click(function() {
          var Password = $('#txt-input-password').val();
          console.log(Password);
          var ConfirmPassword = $('#txt-input-password-confirm').val();
          console.log(ConfirmPassword);
          $('#txt-input-password').removeClass('bg-warning');
          $('#txt-input-password-confirm').removeClass('bg-warning');
          if (Password == ConfirmPassword) {
            ValidationPass = true;
            CheckValidation(ValidationPass);
            console.log('Password & ConfirmPassword: true');
            return true;
          }else{
            ValidationPass = false;
            CheckValidation(ValidationPass);
            $('#txt-input-password').addClass('bg-warning');
            $('#txt-input-password-confirm').addClass('bg-warning');
            return false;
          }
        })
      }
      // if validate fail this function will lock the submit button
      function CheckValidation(ValidationPass) {
        if (ValidationPass == true) {
          $('#AddNewEmployeeBtn').prop('disabled',false).removeClass('btn-secondary').addClass('btn-sucess');
        }else{
          $('#AddNewEmployeeBtn').prop('disabled',true).removeClass('btn-primary').addClass('btn-secondary');
        }
      }
      // validate name format //
      function ANameValidate(NameValue){
        var ANameRegEx= /^[^!@#.$%^&*()_+-=].{1,35}$/;
        console.log('Aname = ' + ANameRegEx.test(NameValue));
        return ANameRegEx.test(NameValue);
      }
      // validate phone number format //
      function APhoneValidate(PhoneValue){
        var APhoneRegEx= /^[\d]{2,13}$/;
        console.log('Aphone = ' + APhoneRegEx.test(PhoneValue));
        return APhoneRegEx.test(PhoneValue);
      }
      // validate email format //
      function AEmailValidate(EmailValue){
        var AEmailRegEx= /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        console.log('AEmail = ' + AEmailRegEx.test(EmailValue));
        return AEmailRegEx.test(EmailValue);
      }
      //   // validate old password //
      function APasswordValidate(PasswordValue){
        var APasswordRegEx= /^.\S{1,}$/;
        console.log('APassword = ' + APasswordRegEx.test(PasswordValue));
        return APasswordRegEx.test(PasswordValue);
      }
    }
    // HNF-Customer-Detail Validation //
    function CustomerDetailValidation(){
      Validate();
      function Validate() {
        var ValidationPass = true;
        $('#txt-CName').focusout(function() {
          var CustomerName = $('#txt-CName').val();
          $('#txt-CName').removeClass('bg-warning');
          if (CName_Format_Validate(CustomerName)) {
            // $('#CustomerInfoSaveBtn').prop('disabled',false).removeClass('btn-secondary').addClass('btn-primary');
            ValidationPass = true;
            CheckValidation(ValidationPass);
          }else{
            ValidationPass = false;
            CheckValidation(ValidationPass)
            // $('#CustomerInfoSaveBtn').prop('disabled',true).removeClass('btn-primary').addClass('btn-secondary');
            $('#txt-CName').val('').addClass('bg-warning');

          }
        });
        $('#txt-CPhone').focusout(function() {
          var CustomerPhone = $('#txt-CPhone').val();
          $('#txt-CPhone').removeClass('bg-warning');
          if (CPhone_Format_Validate(CustomerPhone)) {
            ValidationPass = true;
            CheckValidation(ValidationPass);
          }else{
            ValidationPass = false;
            CheckValidation(ValidationPass)
            // $('#CustomerInfoSaveBtn').prop('disabled',true).removeClass('btn-primary').addClass('btn-secondary');
            $('#txt-CPhone').val('');
            $('#txt-CPhone').addClass('bg-warning');
          }
        })
        $('#txt-CEmail').focusout(function () {
          var CustomerEmail = $('#txt-CEmail').val();
          $('#txt-CEmail').removeClass('bg-warning');
          if (CEmail_Format_Validate(CustomerEmail)) {
            $('#CustomerInfoSaveBtn').prop('disabled',false).removeClass('btn-secondary').addClass('btn-primary');
          }else {
            $('#CustomerInfoSaveBtn').prop('disabled',true).removeClass('btn-primary').addClass('btn-secondary');
            $('#txt-CEmail').val('');
            $('#txt-CEmail').addClass('bg-warning');
          }
        })
        $('#txt-CPrice').focusout(function() {
          var numcheck = $('#txt-CPrice').val();
          console.log("Price : " + numcheck);
          $('#txt-CPrice').val(AntiNegativeValue(numcheck));
        });
        $('#txt-CQuantity').focusout(function() {
          var numcheck = $('#txt-CQuantity').val();
          $('#txt-CQuantity').val(AntiNegativeValue(numcheck));
        });
        $('#txt-CPriceRange').focusout(function() {
          var numcheck = $('#txt-CPriceRange').val();
          $('#txt-CPriceRange').val(AntiNegativeValue(numcheck));
        })
        $('#txt-CCompany').focusout(function(){
          var txtValue = $('#txt-CCompany').val();
          if (COther_Format_Validate(txtValue) != true) {
            $('#txt-CCompany').val('');
          }
        })
        $('#txt-CJob').focusout(function(){
          var txtValue = $('#txt-CJob').val();
          if (COther_Format_Validate(txtValue)!= true) {
            $('#txt-CJob').val('');
          }
        })
        $('#txt-CShirtBefore').focusout(function(){
          var txtValue = $('#txt-CShirtBefore').val();
          if (COther_Format_Validate(txtValue)!= true) {
            $('#txt-CShirtBefore').val('');
          }
        })
        $('#txt-CFabricBefore').focusout(function(){
          var txtValue = $('#txt-CFabricBefore').val();
          if (COther_Format_Validate(txtValue)!= true) {
            $('#txt-CFabricBefore').val('');
          }
        })
        $('#txt-CReview').focusout(function(){
          var txtValue = $('#txt-CReview').val();
          if (COther_Format_Validate(txtValue)!= true) {
            $('#txt-CReview').val('');
          }
        })
        $('#txt-CCompanyBefore').focusout(function(){
          var txtValue = $('#txt-CCompanyBefore').val();
          if (COther_Format_Validate(txtValue)!= true) {
            $('#txt-CCompanyBefore').val('');
          }
        })
        $('#txt-CShirtType').focusout(function(){
          var txtValue = $('#txt-CShirtType').val();
          if (COther_Format_Validate(txtValue)!= true) {
            $('#txt-CShirtType').val('');
          }
        })
        $('#txt-CFabricType').focusout(function(){
          var txtValue = $('#txt-CFabricType').val();
          if (COther_Format_Validate(txtValue)!= true) {
            $('#txt-CFabricType').val('');
          }
        })
        $('#txt-CGoal').focusout(function(){
          var txtValue = $('#txt-CGoal').val();
          if (COther_Format_Validate(txtValue)!= true) {
            $('#txt-CGoal').val('');
          }
        })
        $('#txt-CPrint').focusout(function(){
          var txtValue = $('#txt-CPrint').val();
          if (COther_Format_Validate(txtValue)!= true) {
            $('#txt-CPrint').val('');
          }
        })
        $('#txt-CGoal').focusout(function(){
          var txtValue = $('#txt-CGoal').val();
          if (COther_Format_Validate(txtValue)!= true) {
            $('#txt-CGoal').val('');
          }
        })
      }

      function CheckValidation(ValidationPass) {
        if (ValidationPass == true) {
          $('#CustomerInfoSaveBtn').prop('disabled',false).removeClass('btn-secondary').addClass('btn-primary');
        }else{
          $('#CustomerInfoSaveBtn').prop('disabled',true).removeClass('btn-primary').addClass('btn-secondary');
        }
      }
      // check name format
      function CName_Format_Validate(txtCustomerName) {
        var CustomerNameRegex = /^([^-!@#$;%ˆ&*'()<>.?[{[}/^,:\\\]\~\`{}0-9])+$/;
        console.log('Customer Name : ' + CustomerNameRegex.test(txtCustomerName));
        return CustomerNameRegex.test(txtCustomerName);
      }
      // check phone format
      function CPhone_Format_Validate(txtCustomerPhone) {
        var CustomerPhoneRegex = /^[\d]{2,13}$/;
        console.log('Customer Phone : '+CustomerPhoneRegex.test(txtCustomerPhone));
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
        var CustomerOther = /^[^-\s]([^-!@#$;%ˆ&*'()<>.?[{[}/^,:\\\]\~\`]){0,35}$/;
        console.log(CustomerOther.test(txtField));
        return CustomerOther.test(txtField);
      }
      // make negative number into positive
      function AntiNegativeValue(num){
        if (num < 0) {
          num = -num;
          return num;
        }
        return num;
      }
    }
    // HNF-Customer-ContractDetail-DetailDesign //
    function ContractDetailDesignValidation(){
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
          DDesign_Total_Quantity_Validate(MSmall,MMedium,MLarge,MXLarge,MXXLarge,MXXXLarge,FSmall,FMedium,FLarge,FXLarge,FXXLarge,FXXXLarge,TotalShirt);
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
        console.log('Total Male Size = '+ TotalMaleSize);

        var TotalFemaleSize = FSmall + FMedium + FLarge + FXLarge + FXXLarge + FXXXLarge;
        console.log('Total Female Size = '+TotalFemaleSize);

        var TotalSize = TotalMaleSize + TotalFemaleSize;
        console.log('Total Size = '+TotalSize);
        if (TotalSize == TotalShirt) {
          console.log('equal = ' + true);
          return true;
        }else{
          console.log('equal = ' +false);
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
                data: [Math.random(),Math.random(),Math.random(),Math.random(),Math.random(),Math.random(),Math.random()],
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
                          beginAtZero:true
                      }
                  }]
              }
          }
        });
      // line chart
        var linechart = document.getElementById('LineChart');
        var LineChartData = new Chart(linechart,{
          type: 'line',
          data:{
            labels: ["January", "February", "March", "April", "May", "June", "July"],
            datasets:
              [
                {
                  label: "Doanh Số Bán Hàng",
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
                          beginAtZero:true
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
                  data: [Math.round(Math.random()*100), Math.round(Math.random()*100), Math.round(Math.random()*100)],
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
