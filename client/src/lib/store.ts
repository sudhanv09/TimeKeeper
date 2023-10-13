import { writable } from 'svelte/store'
import { browser } from '$app/environment'

let persistedUser = browser && localStorage.getItem('user')

const initialState = {
    name: '',
    id: ''
}

if (!persistedUser) {
    browser && localStorage.setItem('user', JSON.stringify(initialState))
}
const appState = persistedUser ? JSON.parse(persistedUser) : initialState
// console.log(appState);


export let user = writable(appState)
if (browser) {
    user.subscribe(u => localStorage.setItem('user', JSON.stringify(u)))
}
