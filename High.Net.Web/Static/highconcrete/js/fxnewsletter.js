String.prototype.trim=function(){return this.replace(/^\s\s*/, '').replace(/\s\s*$/, '')};
	function validateForm() {
		if(!validateEmail(document.getElementById("pyuhju-pyuhju").value))
		{
		    $('#lblvalidation').html("Please enter a valid email address.");
			return false;
		}
		return true;
	}
	function validateEmail(email) { 
		var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
		return re.test(email);
	} 