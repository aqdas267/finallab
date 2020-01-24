@ModelType IEnumerable(Of WebApplication1.WebApplication1.Course)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.CourseCode)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CourseName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CreditHours)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CourseCode)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CourseName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CreditHours)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.CourseId }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.CourseId }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.CourseId })
        </td>
    </tr>
Next

</table>
