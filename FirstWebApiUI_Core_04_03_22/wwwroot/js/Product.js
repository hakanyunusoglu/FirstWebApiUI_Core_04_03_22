function LoadProductByApi() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44315/api/Product/LoadProductList",
        dataType: "json",
        contentType: "application/json; charset=UTF-8",
        success: function (returndata) {

        }
    })
}