var Categories = [];
//fetch category from detabase
function LoadCatgory(element) {

    if (Categories.length == 0) {
        $.ajax({

            type="GET",
            URL="home/getProductCatgories",
            success: funtion(data) {
            Categories=data,
            //render category
            renderCatgory(element);
            }
       
      })
} else {
    //render category to the element
    renderCatgory(element);
    }    

}

function renderCatgory(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option>').val("0").text('Select'));
    $.each(Categories, function (i, val) {
        $ele.append($('<option>').val(val.Id).text(val.Name));
    })
}


//fetch products
function LoadProduct(CategoryDD) {
    $.ajax({

        type="GET",
        URL="home/getProducts",
        data: { 'CategoryId': $(CategoryDD).val() },
        success: funtion(data) {
            //render product to appropriete dropdown
            renderProduct($(CategoryDD).parents('mycontainer').find('select.product'), data);

          },
        error: function (error) {
            comsole.log(error);
        }, 
    })

}

function renderProduct(element, data) {
    var $ele = $(element);
    $ele.empty;
    $ele.append($('<option>').val("0").text('Select'));
    $.each(data, function (i, val) {
        $ele.append($('<option>').val(val.Id).text(val.Name));
    })
}

$(document).ready(funtion(){
    //add buuton click event

    $('#add').click(function () {
        var isValid = true;
        if ($('#productCategory').val() == '0') {
            isValid = false;
            $('#productCategory').siblings('span.error').css('visibility', 'visible');

        } else
        {
            $('#productCategory').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#product').val() == '0') {
            isValid = false;
            $('#product').siblings('span.error').css('visibility', 'visible');

        } else {
            $('#product').siblings('span.error').css('visibility', 'hidden');
        }

        if (!($('#quantity').val().trim() != '' && (parseInt($('#quantity').val()||0)))) {
            isValid = false;
            $('#quantity').siblings('span.error').css('visibility', 'visible');

        } else {
            $('#quantity').siblings('span.error').css('visibility', 'hidden');
        }

        if (isValid) {

            var $newRow = $('mainrow').clone().removeAttr('id');

            $('.pc', $newRow).val($('#productCategory').val());
            $('.product', $newRow).val($('#product').val());

            //replace add with remove button
            $('.add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');

        }


    })

})