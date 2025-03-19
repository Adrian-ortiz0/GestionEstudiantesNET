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
    } catch (error) {
        console.error(error, "Algo salio mal")
    }
}