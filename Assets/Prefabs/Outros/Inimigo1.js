#pragma strict

enum EstadoInimigo {
	andando,
	morto,
	atacando,
	parado,
	
}
public var hp:int = 100;
public var estadoInimigo:EstadoInimigo = EstadoInimigo.parado;
private var animacao:Animation;

public var andando:AnimationClip;
public var morto:AnimationClip;
public var atacando:AnimationClip;
public var parado:AnimationClip;
public var vitoria:AnimationClip;

public var velocidade:int=5;
public var distanciaAtaque:float=1;
public var distanciaPerseguicao:float=20;

public var personagem:GameObject;

public var Efeito:GameObject;

private var distancia:float=0;
 
function Update ()
{
	if (estadoInimigo != EstadoInimigo.morto){
		  distancia = Vector3.Distance(this.transform.position,personagem.transform.position);
		
		 if(distancia > distanciaPerseguicao)
		 {
			estadoInimigo = EstadoInimigo.parado;
		 	animacao.CrossFade(parado.name);	 
		 }else if (distancia < distanciaPerseguicao && distancia > distanciaAtaque){
		 	
		 	this.transform.LookAt(personagem.transform.position);
		 	
		 	this.transform.position = 
		 	Vector3.MoveTowards(this.transform.position,
		 	personagem.transform.position, velocidade* Time.deltaTime);
		 	
		 	estadoInimigo = EstadoInimigo.andando;
		 	animacao.CrossFade(andando.name);
		 }else
		 {
		 	if (Personagem.estado != EstadoJogador.morrendo){
		 		estadoInimigo = EstadoInimigo.atacando;
		 		animacao.CrossFade(atacando.name);
		 	}else{
		 		animacao.CrossFade(vitoria.name);
		 		
		 	}
		 	
		 }
	 }
}
 
function Start () {
	animacao = this.gameObject.GetComponent(Animation);
	
}

public function aplicaDano(valor:int){
	if(estadoInimigo != EstadoInimigo.morto ){
		if(this.hp>0){
			animacao.CrossFade("gethit");
			this.hp -=valor;
		}else{
			this.morrer();
		}
	}
	
}

public function morrer (){
	if(estadoInimigo != EstadoInimigo.morto){
		animacao.CrossFade("die");
		estadoInimigo = EstadoInimigo.morto;
		Instantiate(Efeito,this.transform.position,this.transform.rotation);
	}
}
