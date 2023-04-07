import React from "react";

function NeedsAdminModal({ isVisible }) {

  return (
    <div className="flex flex-col max-w-md gap-2 p-6 rounded-md shadow-md dark:bg-gray-900 dark:text-gray-100">
      <h2 className="text-xl font-semibold leading-tight tracking-wide">
        Needs Admin access
      </h2>
      <p className="flex-1 dark:text-gray-400">
        For security reasons you need to login as admin to proceed. Please
        contact supervisor.
      </p>
      <div className="flex flex-col justify-between gap-6 mt-6 sm:flex-row">
        <button className="px-6 py-2 rounded-sm shadow-sm dark:bg-violet-400 dark:text-gray-900">
          Continue
        </button>
      </div>
    </div>
  );
}

export default NeedsAdminModal;
