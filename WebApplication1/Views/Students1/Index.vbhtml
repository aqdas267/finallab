@ModelType IEnumerable(Of WebApplication1.WebApplication1.Student)
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
            @Html.DisplayNameFor(Function(model) model.StudentName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.StudentRegNo)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.StudentSemester)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.StudentName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.StudentRegNo)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.StudentSemester)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.StudentId }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.StudentId }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.StudentId })
        </td>
    </tr>
Next

</table>
