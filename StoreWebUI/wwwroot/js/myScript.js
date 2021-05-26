/
function LoadProduct() {
    $.ajax({

        type="GET",
        URL="home/GetAllProducts",
        data: {},
        success: funtion(data) {

          },
        error: function (error) {
            comsole.log(error);
        }, 
    })

}

function renderProduct(element, data) {
    var $ele = $(element);
    $ele.empty;
    $ele.append($('<option>').val("#").text('Select'));
    $.each(data, function (i, val) {
        $ele.append($('<option>').val(val.Id).text(val.Name));
    })
}