function clearTextArea() {
    $('textarea[name=comment]').val("");
}

$("#addAnimalSubmit").on("click", function () {
    var formInfo = $("#addAnimalFormInfo");
    $.ajax({
        url: $("#AddNewAnimal").val(),
        type: 'post',
        data: formInfo.serialize(),
        success: function () {
            new PNotify({
                title: 'Regular Success',
                text: 'That thing that you were trying to do worked!',
                type: 'success'
            });
            UpdateView(formInfo.find('input[name="Category.Name"]').val());
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("addAnimalSubmit: " + errorThrown);
        }
    });
});

$(function () {
    $.each($("#categoryList").children(), function (index, value) {
        if ($(this).val() != "0") {
            $(this).addClass("category-item");
        }
    });
});

$(function () {
    PNotify.prototype.options.styling = "bootstrap3";
});

$("#categoryList").on("change", function (e) {
    var select = e.target;
    var option = select.options[select.selectedIndex];
    if ($(option).hasClass('category-item')) {
        $.ajax({
            method: "POST",
            url: $("#GetAnimalsInCategory").val(),
            data: { categoryId: $("#categoryList option:selected").val() },
            success: function (content) {
                $("#animalListContainer").html(content);
            },
            error: function () {
                alert($(this).val());
            }
        });
    }
});

function UpdateView(categoryName) {
    $.post($("#GetAnimalsInCategoryByName").val(), { categoryName: categoryName })
    .done(function (data) {
        $("#animalListContainer").html(data);
    });
};