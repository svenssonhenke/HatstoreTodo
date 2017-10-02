$(document).on("click", "a#createNewTodo", function (e) {
    e.preventDefault();
    var url = $(this).attr("href");
    var $text = $("#createTodoText").val();

    $.post(url, { createTodoText: $text }, function (data) {
        $("#todoList").append(data);
        $("#createTodoText").val("");
        $("#NoTodosText").addClass("hidden");
    });

});
$(document).on("click", "a.setDone", function (e) {
    e.preventDefault();
    var url = $(this).attr("href");
    var $container = $(this).closest(".todoItem");
    var $id = $container.find(".todoItemText").attr("id");
    
    $.post(url, { itemId: $id }, function (data) {
        $container.html($(data).find(".todoItem"));
    });

});
$(document).on("click", "a.delete", function (e) {
    e.preventDefault();
    var url = $(this).attr("href");
    var $container = $(this).closest(".todoItem");
    var $id = $container.find(".todoItemText").attr("id");

    $.post(url, { itemId: $id }, function (data) {
        $container.closest(".row").fadeOut();
    });
});
