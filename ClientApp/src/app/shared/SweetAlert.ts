import { Injectable } from "@angular/core";
import Swal from "sweetalert2";

@Injectable()
export class SweetAlert {
  constructor() {}

  /** A Função ShowAlert passa como parametro o title, text e icon. Ambos sendo do tipo string, com excessão do Icon que pode ser qualquer um dos alertas.
     * @param title Refere-se ao título usado no alerta, ex: SUCESSO!
     * @param text Texto usado para especificar o que quer dizer o alerta, ex: SALVO COM SUCESSO!
     * @param icon  Icone que representa o tipo de alerta, ex: success
     * @param autoClose Se definido será o tempo em milisegundos para o alerta fechar automaticamente.
     */
   public ShowAlert(
      title: string,
      text: string,
      icon: 'success' | 'warning' | 'info' | 'error',
      autoClose = 0
  ) {
      Swal.fire({
          title,
          html: text,
          icon,
          showConfirmButton: true,
          confirmButtonText: 'OK',
      });

      if(autoClose > 0){
          setTimeout(e =>{
              Swal.close();
          },autoClose)
      }
  }


      /**
     * Função para exibir uma janela de confirmação
     * @param title Refere-se ao título usado no alerta, ex: SUCESSO!
     * @param text Texto usado para especificar o que quer dizer o alerta, ex: SALVO COM SUCESSO!
     * @param confirmButtonText Texto do botão de confirmação
     * @param cancelButtonText Texto do botão de cancelamento
     * @param confirmFunction  Função que retorna se a opção foi Confirmada
     * @param cancelFunction Função que retorna se a opção foi Cancelada
     */
       public ShowConfirm(
        title: string,
        text: string,
        confirmButtonText: string,
        cancelButtonText: string,
        confirmFunction: Function,
        cancelFunction: Function
    ) {
        if (!title) {
            title = 'Confirmar';
        }

        if (!text) {
            text = 'Deseja continuar?';
        }

        if (!confirmButtonText) {
            confirmButtonText = 'OK';
        }

        if (!cancelButtonText) {
            cancelButtonText = 'Cancelar';
        }

        // Não recebe parametros
        Swal.fire({
            title,
            html: text,
            icon: 'question',
            showConfirmButton: true,
            confirmButtonText,
            showCancelButton: true,
            cancelButtonText,
        }).then((willDelete) => {
            if (willDelete.value) {
                confirmFunction();
            } else {
                if (cancelFunction) {
                    cancelFunction();
                } else {
                    Swal.close();
                }
            }
        });
    }
}
