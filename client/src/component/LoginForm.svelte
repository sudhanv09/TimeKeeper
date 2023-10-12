<script lang="ts">

	import { goto } from "$app/navigation";
	import { user } from "$lib/store";

	let username: string 
	let password: string 
	let persistent: boolean = false

	async function handleLogin() {		
		const response = await fetch('http://localhost:5145/user/login', {
			method: 'POST',
			body: JSON.stringify({ username, password, persistent }),
			headers: {
				'Content-Type': 'application/json'
			}
		});

		const data = await response.json();
		user.update(prev => ({...prev, name: username, id: data.id}))

		goto(`/user/${data.id}`)
	}
</script>

<form
	on:submit|preventDefault={handleLogin}
	class="mt-6 mb-0 space-y-4 rounded-lg p-4 shadow-lg sm:p-6 lg:p-8"
>
	<p class="text-center font-bold text-4xl">Sign in to your account</p>

	<div class="mt-6 space-y-6">
		<div class="relative">
			<input
				type="text"
				bind:value={username}
				class="w-full rounded-lg border-gray-200 p-4 pr-12 text-sm text-black shadow-sm"
				placeholder="Enter username"
			/>
		</div>
		<div class="relative">
			<input
				type="password"
				bind:value={password}
				class="w-full rounded-lg border-gray-200 p-4 pr-12 text-sm text-black shadow-sm"
				placeholder="Enter password"
			/>
		</div>
		<label class="flex items-center space-x-2">
			<input class="checkbox" type="checkbox" bind:checked={persistent} />
			<p>Keep me logged in</p>
		</label>
	</div>

	<div class="flex justify-end text-xs dark:text-gray-400">
		<button>Forgot Password?</button>
	</div>

	<button
		type="submit"
		class="block w-full rounded-lg bg-indigo-600 px-5 py-3 text-sm font-medium text-white"
	>
		Sign in
	</button>

	<p class="text-center text-sm text-gray-500">
		No account?
		<a class="underline pl-2" href="/register"> Sign up </a>
	</p>
</form>
