$(function() {
    window.jsonForm = new JsonForm()
    var Form1Payload = {
        submit_button_text:"Crear formulario",
        fields: [
            {
                id: "requestNo",
                name: "No. de Solicitud",
                type: "field",
                field: {
                    type: "text",
                    readonly:true,
                    width: "5",
                    required:false
                }
            },
            {
                id: "lastUpdate",
                name: "Última modificación",
                type: "field",
                field: {
                    type: "text",
                    readonly:true,
                    width: "7",
                    required:false
                }
            },
            {
                id: "",
                name: "Divisor",
                type: "html",
                html: "<hr />"
            },
            {
                id: "name",
                name: "Nombre",
                type: "field",
                field: {
                    type: "text",
                    width: "12",
                    required:false
                }
                
            },
            {
                id: "header",
                name: "Encabezado",
                type: "field",
                field: {
                    type: "textarea",
                    width: "12",
                    required:false
                }
            },
            {
                id: "leftLogo",
                name: "Logo izquierdo",
                type: "field",
                field: {
                    type: "file",
                    width: 4,
                    helptext: "Seleccionar logo izquierdo",
                    required:false
                }
            },
            {
                id: "rightLogo",
                name: "Logo derecho",
                type: "field",
                field: {
                    type: "file",
                    width: 4,
                    helptext: "Seleccionar logo derecho",
                    required:false
                }
            },
            {
                id: "title",
                name: "Título",
                type: "field",
                field: {
                    type: "textarea",
                    rows:2,
                    width: "12",
                    required:false
                }
            },
            {
                id: "registerCode",
                name: "Código de registro de soicitud",
                type: "field",
                field: {
                    type: "text",
                    width: "12",
                    required:false
                }
            },
            {
                id: "resumeText",
                name: "Texto resumen de normativa",
                type: "field",
                field: {
                    type: "textarea",
                    rows: 3,
                    width: "12",
                    required:false
                }
            },
            {
                "id": "",
                "name": "Divisor",
                "type": "html",
                "html": "<hr/><strong>Agregar disclaimers</strong>"
            },
            {
                "id": "disclaimers",
                "name": "",
                "type": "field",
                "field": {
                  "type": "list",
                  "placeholder": "Disclaimer",
                  "helptext": "Ingrese el disclaimer y presione '+'",
                    required:false
                }
            },
            {
                "id": "",
                "name": "Divisor",
                "type": "html",
                "html": "<hr><strong>Agregar requisitos</strong>"
            },
            {
                "id": "requirements",
                "name": "",
                "type": "field",
                "field": {
                  "type": "list",
                  "placeholder": "Requisito",
                  "helptext": "Ingrese el requisito y presione '+'",
                  required:false
                }
            },
        ]
    }
    $("#json").text(JSON.stringify(Form1Payload, null, 2))
    window.jsonForm.create("#Form1", Form1Payload, "Form1")
    window.jsonForm.registerSubmit(Form1Handler, "Form1")

    function Form1Handler(valid, data) {
        
        if (valid) {
            console.log(JSON.stringify(data));
            var data = JSON.stringify(data)
            $.post("/Home/Create", { JsonData : data });
            
        } else {
            $("#Form1Data").text("Form is NOT VALID. Did you fill out all fields?")
        }
    }
})