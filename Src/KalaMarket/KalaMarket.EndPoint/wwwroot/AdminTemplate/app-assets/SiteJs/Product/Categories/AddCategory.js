var form = document.querySelector("#myAddCategoryForm");
var submitBtnCategory = document.querySelector("#submitBtnCategory");
var IsSelect = false;
form.addEventListener('submit',
    (e) => {
        console.log(IsSelect);
        if (IsSelect == false) {
            e.preventDefault();
            AddNewCategory(e);
        }
    });
function AddNewCategory(e) {
    swal.fire({
        title: 'دسته بندی جدید',
        text: "آیا میخواهید دسته بندی جدید به لیست دسته بندی ها اضافه شود؟",
        icon: 'info',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله، اضافه شود',
        cancelButtonText: 'خیر'
    }).then((result) => {
        if (result.isConfirmed) {
            IsSelect = true;
            submitBtnCategory.click();
        } else {
            IsSelect = false;
        }
    })
}