// Remove Selected User
function Delete(id) {
    Swal.fire({
        icon: "question",
        // icon: "success",
        html: `<h4 class="text-danger">آیا واقعا میخواهید کاربر را  حذف کنید</h4>`,
        showCloseButton: true,
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
                url: `/api/Admin/User/${id}`,
                method: "DELETE"
            }).done(function(result) {
                Swal.fire({
                    icon: "success",
                    text: result.message,
                    customClass: {
                        confirmButton: "btn btn-info mx-2"
                    },
                    buttonsStyling: false
                }).then(() => {
                    location.reload(true);
                });

            }).fail(function(result) {
                Swal.fire({
                    icon: "error",
                    text: result.responseJSON.message,
                    customClass: {
                        confirmButton: "btn btn-info mx-2"
                    },
                    buttonsStyling: false
                });
            });
        } else {
            Swal.fire({
                icon: "info",
                text: "درخواست کنسل شد",
                customClass: {
                    confirmButton: "btn btn-info mx-2"
                },
                buttonsStyling: false
            });
        }
    });

}