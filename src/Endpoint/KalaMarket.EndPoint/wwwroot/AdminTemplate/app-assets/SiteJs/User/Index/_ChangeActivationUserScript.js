﻿
function ChangActivation(id) {
    Swal.fire({
        icon: "question",
        html: `<h4 class="text-info">آیا میخواهید وضعیت کاربر \n را تغیر بدهید ؟</h4>`,
        showCloseButton: true,
        showConfirmButton: true,
        showCancelButton: true,
        focusConfirm: false,
        confirmButtonText: "بله",
        cancelButtonText: "نه",
        customClass: {
            cancelButton: "btn btn-danger  mx-2",
            confirmButton: "btn btn-success  mx-2",
        },
        buttonsStyling: false,
    }).then((res) => {
        if (res.isConfirmed) {
            $.ajax({
                url: `Users/index/ChangeUserActivation?id=${id}`,
                method: "Put",
                beforeSend: function(xhr) {
                    xhr.setRequestHeader("XSRF-TOKEN",
                        $(`input:hidden[name="__RequestVerificationToken"]`).val());
                }
            }).done((result) => {
                Swal.fire({
                    icon: "success",
                    html: `<h4 class="text-info"> ${result.message}</h4>`,
                    showCloseButton: true,
                    showConfirmButton: true,
                    focusConfirm: false,
                    confirmButtonText: "بله",
                    timer: 5000,
                    customClass: {
                        confirmButton: "btn btn-success  mx-2",
                    },
                    buttonsStyling: false,
                }).then(() => {
                    location.reload(true);
                });
            }).fail((result) => {
                var message;
                if (result.status == 404) var message = "مشکلی بوجود آمده است";
                else {
                    message = result.responseJSON.message;
                }
                Swal.fire({
                    icon: "error",
                    html: `<h4 class="text-info"> ${message}</h4>`,
                    showCloseButton: true,
                    showConfirmButton: true,
                    focusConfirm: false,
                    confirmButtonText: "تایید",
                    timer: 5000,
                    customClass: {
                        confirmButton: "btn btn-danger  mx-2",
                    },
                    buttonsStyling: false,
                });
            });
        }
    });
}