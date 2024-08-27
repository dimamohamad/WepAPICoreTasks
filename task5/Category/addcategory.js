var url = "https://localhost:44358/api/Categories";
var form = document.getElementById("form");
async function fun() {
    event.preventDefault();
    var formData = new FormData(form);
    let response = await fetch(url, {
        method: 'POST',
        body: formData,
    });
    var data = response;
    // localStorage.setItem("CategoryId",id);
    window.location.href = "../Admin/Admin.html"
    alert ("your category have been added successfully")
}