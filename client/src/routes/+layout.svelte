<script lang="ts">
	import '../app.postcss';
	import { user } from '$lib/store';
	import { AppShell } from '@skeletonlabs/skeleton';

	// Floating UI for Popups
	import { computePosition, autoUpdate, flip, shift, offset, arrow } from '@floating-ui/dom';
	import { storePopup } from '@skeletonlabs/skeleton';
	storePopup.set({ computePosition, autoUpdate, flip, shift, offset, arrow });
</script>

<AppShell>
	<svelte:fragment slot="header">
		<div class="flex justify-between p-6 text-xl font-semibold">
			<a href="/">Home</a>
			<a href={`/user/${$user.id}`}>Welcome {$user.name}</a>
		</div>
	</svelte:fragment>

	<slot />

</AppShell>