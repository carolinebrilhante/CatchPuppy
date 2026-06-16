using UnityEngine;
using UnityEngine.Rendering;

public class CatchPuppy : MonoBehaviour
{
    // atributos do jogador
    [Header("0 Fogo | 1 Pedra | 2 Água")]

    //escolhas do jogador
    [SerializeField] private int playerPuppy;
    private int cpuPuppy;

    //dados da partida
    private int playerScore;
    private int cpuScore;
    private int empates;

    //controla as rodadas
    private int rodadas;

    //array
    string[] historicoPartida = new string[5];

    private void Start()
    {
        //inicialização
        playerScore = 0;    
        cpuScore = 0;
        empates = 0;
        rodadas = 0;
    }

    private void Update()
    {
        //executa partida
        if(Input.anyKeyDown && rodadas < 5)
        {
            //valida escolha do jogador
            if(playerPuppy >= 0 && playerPuppy < 3)
            {
                //escolha da cpu
                cpuPuppy = dadoEscolhePuppy(3);

                print("Puppy do jogador: " + exibirEscolha(playerPuppy));
                print("Puppy da cpu: " + exibirEscolha(cpuPuppy));

                rodadas++;

                //verifica rodada
                verificaRodada();

                //verificar fim
                if(rodadas == 4)
                {
                    finalizarJogo();
                }
            }
            else
            {
                print("O puppy informado não existe!");
            }
        }
    }

    string exibirEscolha(int escolha)
    {

        if (rodadas <= 4 == false) return string.Empty;

        switch (escolha)
        { 
            case 0:
                return "Puppy de fogo";
            case 1:
                return "Puppy de pedra";
            case 2:
                return "Puppy de água";
            default:
                return null;

        }
    }

    void verificaRodada()
    {
        //empate
        if(playerPuppy == cpuPuppy)
        {
            empates++;
            registrarHistorico("Rodada " + rodadas + " : Empatou");
        }else if((playerPuppy == 0 && cpuPuppy == 1) || (playerPuppy == 1 && cpuPuppy == 2) || (playerPuppy == 2 && cpuPuppy == 0))
        {
            playerScore++;
            registrarHistorico("Rodada " + rodadas + " : Puppy foi capturado!");
        }
        else
        {
            cpuScore++;
            registrarHistorico("Rodada " + rodadas + " : Puppy escapou!");
        }
    }

    void registrarHistorico(string texto)
    {
        historicoPartida[rodadas] = texto;
        print(historicoPartida[rodadas]);

    }


    void finalizarJogo()
    {
        //exibe o resultado da partida
        print("Fim do jogo --------------");
        foreach(string texto in historicoPartida)
        {
            print(texto);
        }

        //exibe resultados finais
        print(playerScore + " puppys foram capturados");
        print(cpuScore + " puppys fugiram");
        print(empates + " empates");

    }




    //função q simula um dado
    int dadoEscolhePuppy(int lados)
    {
        return Random.Range(0, lados);
    }

}