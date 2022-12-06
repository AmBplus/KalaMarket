
//#region Add Jpg Validator
jQuery.validator.addMethod("ValidFileExtension",
    function(value, element, param) {
        var extension = value.slice(((value.lastIndexOf(".") - 1) + 2));
        const validExtension = ["png", "jpeg", "jpg", "webp"];
        const result = validExtension.some((ex) => ex === extension);
        return result;
    });
jQuery.validator.unobtrusive.adapters.addBool("ValidFileExtension");

var isInputFeatureAdded = false;
var AddProductForm = document.querySelector("#AddProductForm");
var btnSubmitProductForm = document.querySelector("#btnAddProduct");
var countTagForProduct = 0;
AddProductForm.addEventListener("submit",
    (e) => {
        console.log("inputValue");
        console.log(isInputFeatureAdded);
        if (isInputFeatureAdded === true) {
            isInputFeatureAdded = false;
            $("#btnAddProduct").prop("disabled", true);
        } else {
            e.preventDefault();
            addInputFeatures();
            $("#btnAddProduct").click();
        }
    });
//#endregion /Add Jpg Validator

//#region Add Feature To Table
$("#btnAddFeatures").on("click",
    function() {
        const txtDisplayName = $("#Feature_Key").val();
        const txtValue = $("#Feature_Value").val();
        if (txtDisplayName == "" || txtValue == "") {
            swal.fire(
                "هشدار!",
                "نام و مقدار را باید وارد کنید",
                "warning"
            );
        } else {
            if (CheckProductFeatureExist(txtDisplayName) === true) {
                swal.fire(
                    "!خطا",
                    "ویژگی تکراریست",
                    "error"
                );
            } else {
                isInputFeatureAdded = false;
                $("#tbl_Features tbody")
                    .append(
                        `<tr> <td>${txtDisplayName}</td>  <td>${txtValue
                        }</td> <td> <a class="idFeatures btnDelete btn btn-danger"> حذف </a> </td> </tr>`);
                $("#txtDisplayName").val("");
                $("#txtValue").val("");
            }
        }
    });
//#endregion /Add Feature To Table

//#region   Check Feature Exist In Table Features    
function CheckProductFeatureExist(feature) {
    const dataFeaturesViewModel = $("#tbl_Features tr:gt(0)").map(function() {
        return {
            DisplayName: $(this.cells[0]).text(),
        };
    }).get();
    var result = false;
    $.each(dataFeaturesViewModel,
        function(i, val) {
            console.log(val.DisplayName);
            if (val.DisplayName === feature) {
                result = true;
            }
        });
    return result;
}
//#endregion /Check Feature Exist In Table Features

//#region Remove Selected Row In Table Features
$("#tbl_Features").on("click",
    ".idFeatures",
    function() {
        $(this).closest("tr").remove();
    });
//#endregion /Remove Selected Row In Table Features

//#region Add Hidden Input For Bind Features To BackEnd
function addInputFeatures() {
    var List_Feature = $("#List_Feature");
    List_Feature.empty();
    const ShowError = $("#Show_Errors");
    ShowError.empty();
    const dataFeaturesViewModel = $("#tbl_Features tr:gt(0)").map(function() {
        return {
            DisplayName: $(this.cells[0]).text(),
            Value: $(this.cells[1]).text(),
        };
    }).get();
    if (dataFeaturesViewModel.length === 0) {
        swal.fire(
            "هشدار!",
            "باید یک ویژگی وارد کنید",
            "warning"
        );
    }
    $.each(dataFeaturesViewModel,
        function(i, val) {
            List_Feature.append(
                `<input name="Features[${i}].KeyName" id="Features_${i
                }__KeyName" type="hidden" data-val="true" value="${val.DisplayName}"/></br>`);
            List_Feature.append(
                `<input name="Features[${i}].KeyValue" id="Features_${i}__KeyValue" type="hidden"  value="${val.Value
                }"/></br>`);
            isInputFeatureAdded = true;
        });
    const formProduct = $("#AddProductForm");
    //sets up the validate
    formProduct.validate();
    //checks if it's valid
    if (formProduct.valid()) {
        //horray it's valid
        formProduct.prop("disabled", true);
        formProduct.submit();
    }

}
//#endregion /Add Hidden Input For Bind Features To BackEnd