@ModelType IEnumerable(Of WebApplication1.WebApplication1.CourseRegistration)
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
            @Html.DisplayNameFor(Function(model) model.CourseId)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.StudentId)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.RegistrationTime)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CourseId)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.StudentId)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.RegistrationTime)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.CourseRegistrationId }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.CourseRegistrationId }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.CourseRegistrationId })
        </td>
    </tr>
Next

</table>
