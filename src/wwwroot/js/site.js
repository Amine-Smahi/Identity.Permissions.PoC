var xmlhttp = new XMLHttpRequest();

function hardreload() {
    setTimeout(function () {
        try {
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == XMLHttpRequest.DONE) {
                    if (xmlhttp.status === 200) {
                        hardreload();
                    } else {
                        WaitTillServerAvailable();
                    }
                }
            };
            xmlhttp.open("GET", "?_=" + new Date().getTime(), true);
            xmlhttp.send();
        } catch (error) { }
    }, 1500);
}
hardreload();

function WaitTillServerAvailable() {
    setTimeout(function () {
        try {
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == XMLHttpRequest.DONE) {
                    if (xmlhttp.status === 200) {
                        location.reload(false);
                    } else {
                        WaitTillServerAvailable();
                    }
                }
            };
            xmlhttp.open("GET", "?_=" + new Date().getTime(), true);
            xmlhttp.send();
        } catch (error) { }
    }, 500);
}