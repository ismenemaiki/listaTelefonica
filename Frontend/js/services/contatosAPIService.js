angular.module("listaTelefonica").factory("contatosAPI", function ($http, config) {
	var _getContatos = function () {
		return $http.get(config.baseUrl + "/Contacts");
	};

	var _saveContato = function (contato) {
		return $http.post(config.baseUrl + "/contact", contato);
	};

	var _deleteContato = function(id){
		return $http.post(config.baseUrl + "/contact/delete/" + id);
	};

	var _updateContato = function(id){
		return $http.update(config.baseUrl + "/contact/update/" + id);
	};

	return {
		getContatos: _getContatos,
		saveContato: _saveContato,
		deleteContato: _deleteContato,
		updateContato: _updateContato
	};
});