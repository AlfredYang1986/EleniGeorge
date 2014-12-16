function facebook_lib() {
    this.status = '';
    this.facebookLoginSetup();
}

facebook_lib.prototype.fbLoginCallback = function (user) {

    $.ajax({
        url: '/Login/LoginWithFaceBook',
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json, charset=utf-8',
        data: { "fbID": user },
        cache: false,
        //beforeSend: function () {
        //    Loading();
        //},
        //complete: function () {
        //    hiddenLoading();
        //},
        success: function (data) {
            alert(data);

            //var json = eval('(' + data + ')');
            //if (json.success) {
            //    window.location.href = "/Home/Index?user=" + json.name;
            //} else {
            //    alert("login failed");
            //}
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
}

facebook_lib.prototype.statusChangeCallback = function(response) {
    
    console.log('stausChangeCallback');
    console.log(response);

    if (response.status === 'connected') {
        var uid = response.authResponse.userID;
        var accessToken = response.authResponse.accessToken;

        alert("login success");
        this.fbLoginCallback(uid);

    } else if (response.status === 'not_authorized') {
        alert("login failed");
    } else {
        alert("Please log into Facebook.");
    }
}

facebook_lib.prototype.checkLoginState = function () {
    var self = this;

    FB.getLoginStatus(function (response) {
        self.statusChangeCallback(response);
    });

    //FB.login(
    //    FB.getLoginStatus(function (response) {
    //        this.statusChangeCallback(response);
    //    },
    //        { scope: 'public_profile,email' }
    //    ));
}

facebook_lib.prototype.facebookLoginSetup = function () {
    window.fbAsyncInit = function () {
        FB.init({
            appId: '344318099055688', // App ID
            //status: true, // check login status
            cookie: true, // enable cookies to allow the server to access the session
            xfbml: true,  // parse XFBML
            version: 'v2.0'
        });

        FB.getLoginStatus(function (response) {
            this.statusChangeCallback(response);
        });
    };

    // Load the SDK Asynchronously
    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id))
            return;
        js = d.createElement(s); js.id = id;
        js.src = "http://connect.facebook.net/en_US/all.js";
        fjs.parentNode.insertBefore(js, fjs);
    }(document, 'script', 'facebook-jssdk'));
}