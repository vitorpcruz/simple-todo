import { Component, OnInit } from '@angular/core'
import { TodoService } from './todo.service'
import ITodo from '../interfaces/ITodo.interface'
import Swal from 'sweetalert2'
import { NgFor, NgForOf } from '@angular/common'

@Component({
  selector: 'app-todo',
  standalone: true,
  imports: [NgForOf, NgFor],
  templateUrl: './todo.component.html',
  styleUrl: './todo.component.css'
})
export class TodoComponent implements OnInit {
  todoList: ITodo[] = []

  constructor(private todoService: TodoService) {}

  async ngOnInit() {
    await this.fillList()
  }

  async add(todoTitle: string) {
    const titleTrimed = todoTitle.trim()
    if (titleTrimed.length == 0) {
      this.triggerSweetAlert(
        'Ops!',
        'Preencha uma tarefa com um nome válido.',
        false
      )
    }
    await this.todoService.add(todoTitle)
    this.triggerSweetAlert('Tarefa', 'Adicionada com sucesso')
    await this.fillList()
  }

  async remove(todoId: number) {
    await this.todoService.remove(todoId)
    this.triggerSweetAlert('Tarefa', 'Tarefa removida com sucesso')
    await this.fillList()
  }

  async finishTodo(todoId: number) {
    await this.todoService.finishTodo(todoId)
    this.triggerSweetAlert('Tarefa', 'Tarefa finalizada com sucesso')
    await this.fillList()
  }

  private async fillList() {
    await this.todoService
      .findAll()
      .then((list) => {
        this.todoList = list
      })
      .catch((err) => {
        this.triggerSweetAlert('Ops!', err.message, false)
      })
  }

  private triggerSweetAlert(
    title: string,
    text: string,
    success: boolean = true
  ) {
    const icon = success ? 'success' : 'error'

    Swal.fire({
      title,
      text,
      icon: icon,
      confirmButtonText: 'Continuar'
    })
  }
}
