
$('form').jsonForm({
    "schema": {
        "requestNo": {
            "type": "string",
            "title": "No. de Solicitud",
        },
        "lastUpdate": {
            "type": "string",
            "title": "Última modificación"
        },
        "name": {
            "type": "string",
            "title": "Nombre"
        },
        "direction": {
            "type": "string",
            "title": "Dirección",
            "enum": ["SA", "SV"],
        },
        "header": {
            "type": "string",
            "title": "Encabezado"
        },
        "leftLogoBtn": {
            "type": "string",
            "title": "Logo Izquierdo"
        },
        "rightLogoBtn": {
            "type": "string",
            "title": "Logo Derecho"
        },
        "title": {
            "type": "string",
            "title": "Título"
        },
        "registerCode": {
            "type": "string",
            "title": "Código de registro de solicitud"
        },
        "resumeText": {
            "type": "string",
            "title": "Texto resumen de normativa"
        },
        "fields": {
            "type": "array",
            "items": {
                "title": "Ingrese el campo y presione '+'",
                "type": "string",
            }
        },
        "disclaimers": {
            "type": "array",
            "items": {
                "title": "Ingrese el disclaimer y presione '+'",
                "type": "string",
            }
        },
        "requirements": {
            "type": "array",
            "items": {
                "title": "Ingrese el requisito y presione '+'",
                "type": "string",
            }
        }
    },
    "form": [
        {
            "key": "requestNo",
            "type": "text",
            "readonly": "true",
        },
        {
            "key": "lastUpdate",
            "type": "text",
            "readonly": "true"
        },
        {
            "key": "name",
            "type": "text",
        },
        {
            "key": "direction",
            "titleMap": {
                "SA": "Dirección de Sanidad Animal",
                "SV": "Dirección de Sanidad Vegetal"
            }
        },
        {
            "key": "header",
            "type": "textarea",
            "height": "40%",
        },
        {
            "key": "leftLogoBtn",
            "type": "file",
            "accept": ".png,.jpg",
            "onChange": function (evt, node) {
                if (evt.target.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (event) {
                        var dataUrl = event.target.result
                        var img = document.createElement('img')
                        img.src = dataUrl;
                        document.body.appendChild(img);
                        console.log(event.target.result);
                        reader.readAsDataURL(event.target.files[0]);
                    };
                    reader.readAsText(evt.target.files[0]);
                } else {
                    document.getElementsByName('file_content')[0].value = '';
                }
            }
        },
        {
            "key": "rightLogoBtn",
            "type": "file",
            "accept": ".png,.jpg",
        },
        {
            "key": "title",
            "type": "textarea",
            "height": "20%",
        },
        {
            "key": "registerCode",
            "type": "text",
            "height": "20%",
        },
        {
            "key": "resumeText",
            "type": "textarea",
            "height": "30%",
        },
        {
            "type": "array",
            "items": [{
                "key": "fields[]",
                "title": "Campo no. {{idx}}"
            }]
        },
        {
            "type": "array",
            "items": [{
                "key": "disclaimers[]",
                "title": "Disclaimer no. {{idx}}"
            }]
        },
        {
            "type": "array",
            "items": [{
                "key": "requirements[]",
                "title": "Requisito no. {{idx}}"
            }]
        },
        {
            "type": "htmlsnippet",
            "value": "<h1>Hola!</h1>"
        },
        {
            "type": "submit",
            "class": "btn-primary",
            "title": "Enviar",
        },
    ],
    onSubmit: function (errors, values) {
        if (errors) {
        } else {
            console.log(JSON.stringify(values))
        }
    },
},
);