
$('form').jsonForm({
    "schema": {
    
    "requestNo": {
      "type": "string",
      "title": "No. de Solicitud",
      "readOnly" :true
    },
    "lastUpdate": {
      "type": "string",
      "title": "Última modificación",
      "readOnly" :true
    },
    "name": {
      "type": "string",
      "title": "Nombre",
      "pattern": "[A-Za-z]{5}",
      "maxLength": 500,
      "required": true
    },
    "direction": {
      "type": "string",
      "title": "Dirección",
      "enum": [ "NO","SA", "SV"],
      "maxLength": 500,
      "required": true
    },
    "header": {
      "type": "string",
      "title": "Encabezado",
      "pattern": "[A-Za-z]{5}",
      "required": true
    },
    "leftLogo":{
      "type":"string",
      "title":"Logo Izquierdo"
    },
    "rightLogo":{
      "type":"string",
      "title":"Logo Derecho"
    },
    "title": {
      "type": "string",
      "title": "Título",
      "pattern": "[A-Za-z]{5}",
      "maxLength": 500,
      "required": true
    },
    "registerCode": {
      "type": "string",
      "title": "Código de registro de solicitud",
      "pattern": "[A-Za-z]{5}",
      "maxLength": 500,
      "required": true
    },
    "resumeText": {
      "type": "string",
      "title": "Texto resumen de normativa",
      "pattern": "[A-Za-z]{5}",
      "required": true
    },
    "fields": {
      "type": "array",
      "minItems": 1,
      "pattern": "[A-Za-z]{5}",
      "maxLength": 500,
      "required": true,
      "items": {
        "description": "Ingrese el campo y presione '+'",
        "type": "string",
      }
    },
    "disclaimers": {
      "type": "array",
      "minItems": 1,
      "pattern": "[A-Za-z]{5}",
      "maxLength": 500,
      "required": true,
      "items": {
        "description": "Ingrese el disclaimer y presione '+'",
        "type": "string",
      }
    },
    "requirements": {
      "type": "array",
      "minItems": 1,
      "pattern": "[A-Za-z]{5}",
      "maxLength": 500,
      "required": true,
      "items": {
        "description": "Ingrese el requisito y presione '+'",
        "type": "string",
      }
    }
  },
  "form": [
    {
      "key": "requestNo",
      "type": "text",
      "class":"textInfo",
      "readonly":"true",
    },
    {
      "key":"lastUpdate",
      "type": "text",
      "readonly":"true"
    },
    {
      "key":"name",
      "type": "text",
    },
    {
      "key": "direction",
      "titleMap": {
        "NO": "Dirección",
        "SA": "Dirección de Sanidad Animal",
        "SV": "Dirección de Sanidad Vegetal"
      }
    },
    {
      "key":"header",
      "type": "textarea",
      "height": "40%",
    },
    {
      "key":"leftLogo",
      "type":"file",
      "accept":".png,.jpg"
    },
    {
      "key":"rightLogo",
      "type":"file",
      "accept":".png,.jpg",
    },
    {
      "key":"title",
      "type": "textarea",
      "height": "20%",
    },
    {
      "key":"registerCode",
      "type": "text",
      "height": "20%",
      "value":" "
    },
    {
      "key":"resumeText",
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
      "type": "submit",
      "class":"btn-primary",
      "title": "Enviar",
    },

  ],
    onSubmit: function (errors, values) {
        if (errors) {
        } else {
            var data = JSON.stringify(values)
            $.post("/Home/Create", { JsonData: data });
        }
    },
},
);