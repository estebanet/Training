$(function () {
    $('#btnGET').click(function () {
        $.ajax({
            method: 'GET',
            url: 'https://function-app-tests-garo.azurewebsites.net/api/HttpTriggerCSharp1?code=yjKcDjiz9HfcT54aHO36vqUNF8LnRqhzzbUzq8lAkIS3Fd1XCH600A==' +
                '&nombre=' + $('#nameGET').val() + '&apellido=' + $('#apellidoGET').val(),
            dataType: 'json',
            success: function (data) {
                alert('Respuesta recibida (GET): ' + data.Message);
            },
            error: function () {
                alert('Ha fallado la solicitud (GET) hacía la azure function');
            }
        });
    });

    $('#btnPOST').click(function () {
        $.ajax({
            method: 'POST',
            url: 'https://function-app-tests-garo.azurewebsites.net/api/HttpTriggerCSharp1?code=yjKcDjiz9HfcT54aHO36vqUNF8LnRqhzzbUzq8lAkIS3Fd1XCH600A==',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                'nombre': $('#namePOST').val(),
                'apellido': $('#apellidoPOST').val()
            }),
            success: function (data) {
                alert('Respuesta recibida (POST): ' + data.Message);
            },
            error: function () {
                alert('Ha fallado la solicitud (POST) hacía la azure function');
            }
        });
    });
});