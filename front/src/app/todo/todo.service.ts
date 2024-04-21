import { Injectable } from '@angular/core'
import ITodo from '../interfaces/ITodo.interface'
import instance from '../infra/axios-client'

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  private apiUrl = 'https://localhost:4201/todos'

  constructor() {}

  async findAll(): Promise<ITodo[]> {
    return await instance.get(this.apiUrl).then((res) => res.data)
  }

  async remove(todoId: number): Promise<void> {
    await instance.delete(this.apiUrl + '/' + todoId)
  }

  async add(todoTitle: string): Promise<void> {
    const data = { title: todoTitle }
    await instance.post(this.apiUrl, data)
  }

  async finishTodo(todoId: number): Promise<void> {
    await instance.put(this.apiUrl + '/' + todoId)
  }
}
