function LoadProductByApi() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44315/api/Product/LoadProductList",
        dataType: "json",
        contentType: "application/json; charset=UTF-8",
        success: function (returndata) {
            $.each(returndata, function (i, item) {
                $("#TableBody").append(`<tr><td>${item.productID}</td><td>${item.description}</td><td>${item.brand}</td></tr>`);
            });
        },
        error: function () {

        }
    })
}