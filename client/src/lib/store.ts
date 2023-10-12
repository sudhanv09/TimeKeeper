import { writable, get } from 'svelte/store'
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

export let user = writable(appState)
if (browser) {
    user.subscribe(u => localStorage.user = JSON.stringify(u))
}
