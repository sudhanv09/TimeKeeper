<script lang="ts">

    import { goto } from "$app/navigation";

	let schedule: number[];
	let username: string;
	let email: string;
	let password: string;
	let passwdCheck: string;

	async function handleRegister() {
		const response = await fetch('http://localhost:5145/user/create-user', {
			method: 'POST',
			body: JSON.stringify({ username, email, password, schedule }),
			headers: {
				'Content-Type': 'application/json'
			}
		});

		const data = await response.json();
		console.log(data);
		

        goto('/login')
	}
</script>

<form
	on:submit|preventDefault={handleRegister}
	class="mt-6 mb-0 space-y-4 rounded-lg p-4 shadow-lg sm:p-6 lg:p-8"
>
	<p class="text-center font-bold text-4xl">Register Account</p>

	<div class="mt-6 space-y-6">
		<div class="relative">
			<input
				type="text"
				name="username"
				bind:value={username}
				class="w-full rounded-lg border-gray-200 p-4 pr-12 text-sm text-black shadow-sm"
				placeholder="Enter username"
			/>
		</div>
		<div class="relative">
			<input
				type="email"
				name="email"
				bind:value={email}
				class="w-full rounded-lg border-gray-200 p-4 pr-12 text-sm text-black shadow-sm"
				placeholder="Enter email"
			/>
		</div>
		<div class="relative">
			<input
				type="password"
				name="password"
				bind:value={password}
				class="w-full rounded-lg border-gray-200 p-4 pr-12 text-sm text-black shadow-sm"
				placeholder="Enter password"
			/>
		</div>
		<div class="relative">
			{#if passwdCheck !== password}
				<p class="text-red font-light">Passwords dont match</p>
			{/if}
			<input
				type="password"
				bind:value={passwdCheck}
				class="w-full rounded-lg border-gray-200 p-4 pr-12 text-sm text-black shadow-sm"
				placeholder="Confirm password"
			/>
		</div>
	</div>
	<h2 class="m-4">Schedule: {schedule}</h2>
	<div class="grid grid-cols-3 space-y-2">
		<label class="flex items-center space-x-2">
			<input
				class="checkbox"
				name="schedule"
				type="checkbox"
				checked
				bind:group={schedule}
				value={0}
			/>
			<p>Monday</p>
		</label>
		<label class="flex items-center space-x-2">
			<input class="checkbox" name="schedule" type="checkbox" bind:group={schedule} value={1} />
			<p>Tuesday</p>
		</label>
		<label class="flex items-center space-x-2">
			<input class="checkbox" name="schedule" type="checkbox" bind:group={schedule} value={2} />
			<p>Wednesday</p>
		</label>
		<label class="flex items-center space-x-2">
			<input class="checkbox" name="schedule" type="checkbox" bind:group={schedule} value={3} />
			<p>Thursday</p>
		</label>
		<label class="flex items-center space-x-2">
			<input class="checkbox" name="schedule" type="checkbox" bind:group={schedule} value={4} />
			<p>Friday</p>
		</label>
		<label class="flex items-center space-x-2">
			<input class="checkbox" name="schedule" type="checkbox" bind:group={schedule} value={5} />
			<p>Saturday</p>
		</label>
		<label class="flex items-center space-x-2">
			<input class="checkbox" name="schedule" type="checkbox" bind:group={schedule} value={6} />
			<p>Sunday</p>
		</label>
	</div>

	<button
		type="submit"
		class="block w-full rounded-lg bg-indigo-600 px-5 py-3 text-sm font-medium text-white"
	>
		Sign up
	</button>

	<p class="text-center text-sm text-gray-500">
		Already a user?
		<a class="underline pl-2" href="/login"> Sign in </a>
	</p>
</form>
