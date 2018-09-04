angular.module("listaTelefonica").controller("listaTelefonicaCtrl", function ($scope, contatosAPI, operadorasAPI) {
	$scope.app = "Lista Telefonica";
	$scope.contatos = [];
	$scope.operadoras = [];

	var carregarContatos = function () {
		contatosAPI.getContatos().success(function (data) {
			console.log(data);
			$scope.contatos = data;
		}).error(function (data) {
			$scope.message = "Aconteceu um problema: " + data.message;
		});
	};

	var carregarOperadoras = function () {
		operadorasAPI.getOperadoras().success(function (data) {
			console.log(data);
			$scope.operadoras = data;
		});
	};

	$scope.adicionarContato = function (contato) {

		var model = {
			name: contato.nome,
			phoneNumber: contato.telefone,
			carrier:{
				id: contato.operadora.id,
				name: contato.operadora.name,
				price: contato.operadora.price
			}
		};

		contatosAPI.saveContato(model).success(function (data) {
			delete $scope.contato;
			$scope.contatoForm.$setPristine();
			carregarContatos();
		}).error(function (data) {
			$scope.message = data.message;
		});
	};

	$scope.edit = function(contato, i) {
		$scope.update = angular.copy(contato);
		index = i;
		}
	$scope.save = function() {
		$scope.contatos[index] = $scope.update; // captura o objeto modificado e atualiza no original
		
		var model = {
			name: contato.nome,
			phoneNumber: contato.telefone,
			carrier:{
				id: contato.operadora.id,
				name: contato.operadora.name,
				price: contato.operadora.price
			}
		};

		contatosAPI.saveContato(model).success(function (data) {
			delete $scope.contato;
			$scope.contatoForm.$setPristine();
			carregarContatos();
		}).error(function (data) {
			$scope.message = data.message;
		});
		
		}  


	$scope.apagarContato = function () {
		var contato = obterContatoSelecionado();

		contatosAPI.deleteContato(contato.id).success(function(){
			carregarContatos();
		}).error(function (data) {
			$scope.message = data.message;
		});
	};

	function obterContatoSelecionado () {
		return $scope.contatos.filter(function (contato) {
			return contato.selecionado;
		})[0];
	};
	$scope.ordenarPor = function (campo) {
		$scope.criterioDeOrdenacao = campo;
		$scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
	};


	carregarContatos();
	carregarOperadoras();
});