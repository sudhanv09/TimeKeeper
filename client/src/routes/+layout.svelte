<script lang="ts">
	import '../app.postcss';
	import { user } from '$lib/store';

	// Floating UI for Popups
	import { computePosition, autoUpdate, flip, shift, offset, arrow } from '@floating-ui/dom';
	import { storePopup } from '@skeletonlabs/skeleton';
	storePopup.set({ computePosition, autoUpdate, flip, shift, offset, arrow });
</script>

<div class="bg-gradient-to-r from-gray-700 via-gray-900 to-black h-screen">
	<div class="flex p-6 text-xl font-semibold">
		<a href="/">Home</a>
		<h1>Welcome {$user.name}</h1>
	</div>

	<slot />
</div>
