// Configuracion por defecto
$.ajaxSetup({
    data: {
        __RequestVerificationToken: document.getElementsByName(
            "__RequestVerificationToken"
        )[0].value
    }
});

//Guarda y valida estudiantes
async function Salvar()
{
    const form = $("#FormEstudiante").dxForm("instance");
    const valido = form.validate().isValid;

    if (valido)
    {
        alert("Formulario valido");
        const data = form.option("formData");
        console.log(data);
        await EnviarAlServidor(data);
    }
}

async function EnviarAlServidor(dataFormulario) {

    try {

        const response = await $.ajax({
            method: "POST",
            url: "/Estudiantes?handler=CrearEstudiante",
            data: dataFormulario
        });

        alert("Usuario agregado");
        const form = $("#FormEstudiante").dxForm("instance").resetValues();
        $("#TableEstudiantes").dxDataGrid("instance").refresh();

    } catch (error) {
        console.error(error, "Algo salio mal")
    }
}

async function ValidarIdentificacionUnica(e) {
    try {

        const identificacion = e.value;

        const idTipoDocumento = $("FormEstudiante").dxForm("instance").getEditor("TipoDocumento").option("value").id;

        if (idTipoDocumento != 0) {

            const response = await $.ajax({
                method: "GET",
                url: "/Estudiantes?handler=VerificarIdentificacion",
                data: { IdTipoDocumento: idTipoDocumento , documento: identificacion }
            });
            return response;
        }

    } catch (error) {
        console.error(error, "Algo salio mal")
    }
}

function VerEstudianteFromGrid(e) {
    console.log(e);
}

function EditarEstudianteFromGrid(e) {
    console.log(e);
}


function MostrarFormularioAgregar() {
    $("#TableContainer").hide();
    $("#FormContainer").show();
}

function VerTabla() {
    $("#FormContainer").hide();
    $("#TableContainer").show();
}