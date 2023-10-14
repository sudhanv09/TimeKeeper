<script lang="ts">
	import '../app.postcss';
	import { user } from '$lib/store';
	import { AppShell, Toast } from '@skeletonlabs/skeleton';
	import { goto } from '$app/navigation';

	import {initializeStores} from '@skeletonlabs/skeleton';
	initializeStores();

	async function handleLogout() {
		const response = await fetch('http://localhost:5145/user/logout');
		user.set('');
		goto('/', { replaceState: true });
	}
</script>

<Toast />

<AppShell>
	<svelte:fragment slot="header">
		<div class="flex justify-between p-6 text-xl font-semibold">
			<a href="/">Home</a>
			<div class="space-x-4">
				{#if $user}
					<a href={`/user/${$user.id}`}>Welcome {$user.name}</a>
					<button on:click={handleLogout}>Logout</button>
				{/if}
			</div>
		</div>
	</svelte:fragment>

	<slot />
</AppShell>
