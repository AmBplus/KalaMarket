﻿
    $(function() {
        $('form').submit(function (e) {
            if ($(this).valid()) {
                // JQuery در نسخه‌های قدیمی
                //$('button').attr('disabled', 'disabled')
                //$('input[type=button]').attr('disabled', 'disabled')
                // JQuery در نسخه‌های جدید
                $('button').prop('disabled', true);
                $('input[type=button]').prop('disabled', true);
            }
        });
    })
  